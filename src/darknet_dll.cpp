#include <Windows.h>
#include <detours/detours.h>
#include <iostream>
#include <io.h>
#include <fcntl.h>

int stdOutOrg;
int stdErrOrg;

UINT GetTemporaryFilename(LPWSTR str)
{
	WCHAR path[MAX_PATH];
	if (GetTempPathW(MAX_PATH, path) == 0)
	{
		return 0;
	}
	return GetTempFileNameW(path, L"tmp", 0, str);
}

void ResetStdOutBehavior()
{
	_dup2(stdOutOrg, 1);
	_dup2(stdErrOrg, 2);
}

BOOL SetStdOutBehavior(HANDLE* hStdOut, HANDLE* hStdErr)
{
	if (hStdOut == NULL || hStdErr == NULL)
	{
		return FALSE;
	}

	WCHAR outFile[MAX_PATH];
	if (GetTemporaryFilename(outFile) == 0)
	{
		return FALSE;
	}

	WCHAR errFile[MAX_PATH];
	if (GetTemporaryFilename(errFile) == 0)
	{
		return FALSE;
	}

	FILE* fout = _wfreopen(outFile, L"w+", stdout);

	if (!fout)
	{
		return FALSE;
	}

	FILE* ferr = _wfreopen(errFile, L"w+", stderr);

	if (!ferr)
	{
		fclose(fout);
		ResetStdOutBehavior();
		return FALSE;
	}

	setvbuf(fout, NULL, _IONBF, 0);
	setvbuf(ferr, NULL, _IONBF, 0);

	*hStdOut = (HANDLE)_get_osfhandle(_fileno(fout));
	*hStdErr = (HANDLE)_get_osfhandle(_fileno(ferr));

	return TRUE;
}

BOOL useThrowInstead = FALSE;

void SetExitBehavior(BOOL useThrow)
{
	useThrowInstead = useThrow;
}

typedef void(__cdecl* FN_EXIT)(int);
FN_EXIT Originalexit = exit;

void __cdecl Myexit(int _Code)
{
	if (useThrowInstead)
	{
		RaiseException((DWORD)_Code, 0, 0, NULL);
	}

	Originalexit(_Code);
}

struct DetourMap
{
	PVOID* OrgProc;
	PVOID  newProc;
};

#define DETOURPROC(x) { &(PVOID&)Original##x, My##x }

static DetourMap DetourProcs[] = {
	DETOURPROC(exit)
};

void Install()
{
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());

	for (int i = 0; i < sizeof(DetourProcs) / sizeof(*DetourProcs); i++)
	{
		DetourAttach(DetourProcs[i].OrgProc, DetourProcs[i].newProc);
	}

	DetourTransactionCommit();
}

void Uninstall()
{
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());

	for (int i = 0; i < sizeof(DetourProcs) / sizeof(*DetourProcs); i++)
	{
		DetourDetach(DetourProcs[i].OrgProc, DetourProcs[i].newProc);
	}

	DetourTransactionCommit();
}

BOOL WINAPI DllMain(HINSTANCE hModule, DWORD dwReason, LPVOID lpRes)
{
	UNREFERENCED_PARAMETER(lpRes);

	if (dwReason == DLL_PROCESS_ATTACH)
	{
		DisableThreadLibraryCalls(hModule);

		Install();

		stdOutOrg = _dup(1);
		stdErrOrg = _dup(2);
	}
	else if (dwReason == DLL_PROCESS_DETACH)
	{
		Uninstall();
	}

	return TRUE;
}