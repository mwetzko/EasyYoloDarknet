#include <Windows.h>
#include <io.h>
#include <iostream>

typedef int (*MainFunc)(int, char**);

int main(int argc, char** argv)
{
	if (argc > 1 && strcmp(argv[argc - 1], "nullstdin") == 0)
	{
		printf("Redirecting stdin to NUL.\n");
		freopen("NUL:", "r", stdin);
		setvbuf(stdin, NULL, _IONBF, 0);
		argc--;
	}

	HMODULE darknet = LoadLibraryW(L"darknet.dll");

	if (!darknet)
	{
		printf("Cannot load darknet.dll\n");
		return 1;
	}

	FARPROC fmain = GetProcAddress(darknet, "main");

	if (!fmain)
	{
		printf("Cannot locate 'main' entry point in darknet.dll\n");
		return 2;
	}

	return ((MainFunc)fmain)(argc, argv);
}