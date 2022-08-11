using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class ProcessStreamReader
    {
        Stream mStream;
        Decoder mDecoder;
        Task<string> mTask;
        byte[] mBuffer;
        char[] mCharBuffer;

        public ProcessStreamReader(StreamReader reader)
        {
            mStream = reader.BaseStream;
            mDecoder = reader.CurrentEncoding.GetDecoder();
            mBuffer = new byte[1024];
            mCharBuffer = new char[reader.CurrentEncoding.GetMaxCharCount(1024)];
        }

        async Task<string> ReadAsync()
        {
            try
            {
                int num = await mStream.ReadAsync(mBuffer, 0, mBuffer.Length).ConfigureAwait(continueOnCapturedContext: false);

                if (num > 0)
                {
                    int chars = mDecoder.GetChars(mBuffer, 0, num, mCharBuffer, 0);

                    return new string(mCharBuffer, 0, chars);
                }
            }
            catch (IOException)
            {
                // nothing
            }
            catch (OperationCanceledException)
            {
                // nothing
            }

            return null;
        }

        public string ReadStringIfAvailable()
        {
            if (mTask == null)
            {
                mTask = Task.Run(ReadAsync);
            }
            else if (mTask.IsCompleted)
            {
                string res = mTask.GetAwaiter().GetResult();

                mTask = Task.Run(ReadAsync);

                return res;
            }

            return null;
        }

        public string FinalReadString()
        {
            StringBuilder sb = new StringBuilder();

            if (mTask != null)
            {
                sb.Append(mTask.GetAwaiter().GetResult());
            }

            mTask = Task.Run(ReadAsync);

            sb.Append(mTask.GetAwaiter().GetResult());

            return sb.ToString();
        }
    }
}
