using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Amemiya.Extensions;

namespace BGIScrViewer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class BGIUtils
    {
        /// <summary>
        /// Decode the input decompressed BGI script. Mainly written by Amemiya.
        /// </summary>
        /// <param name="filepath">Full path and name of original decompressed script file that to be decoded.</param>
        /// <param name="output">Full path and name of the decoded output text file. Use empty string for not creating output file.</param>
        /// <param name="codepageindex">Codepage for transcode. It should be 932 for Shift-JIS.</param>
        /// <returns>Returns the decoded script lines in a String[] array.</returns>
        public static String[] Process(String filepath, String output, int codepageindex)
        {
            var scr = new System.Collections.ArrayList();
            BinaryReader br = new BinaryReader(new FileStream(filepath, FileMode.Open));

            var scriptBuffer = br.ReadBytes((int)br.BaseStream.Length);
            br.Close();

            // headerLength includes MAGIC and @[0x1C].
            int headerLength = 0;

            // Check whether the file is in new format.
            // The most significant thing is the new format have the magic "BurikoCompiledScriptVer1.00\x00".
            // The difference between old and new is that, the old one DOES NOT have the HEADER which has
            // the length discribed at [0x1C] as a DWORD.
            if (
                scriptBuffer.Slice(0, 0x1C)
                            .EqualWith(new byte[]
                                {
                                    0x42, 0x75, 0x72, 0x69, 0x6B,
                                    0x6F, 0x43, 0x6F, 0x6D, 0x70,
                                    0x69, 0x6C, 0x65, 0x64, 0x53,
                                    0x63, 0x72, 0x69, 0x70, 0x74,
                                    0x56, 0x65, 0x72, 0x31, 0x2E,
                                    0x30, 0x30, 0x00
                                }))
            {
                headerLength = 0x1C + BitConverter.ToInt32(scriptBuffer, 0x1C);
            }

            // Remove HEADER.
            scriptBuffer = scriptBuffer.Slice(headerLength, scriptBuffer.Length);

            // TODO: Analyze more about this offset. Sometime it is marked as 0x00000001 and sometime 0x0000007F.
            // Get the text offset.
            // The offset is always next to 0x0000007F (HEADER length not included).
            int firstTextOffset;
            int offset = scriptBuffer.IndexOf(new byte[] { 0x7F, 0, 0, 0 }, 0, false);
            // Avoid possible overflow.
            if (offset < 0 || offset > 128)
            {
                firstTextOffset = 0;
            }
            else
            {
                firstTextOffset = BitConverter.ToInt32(scriptBuffer, offset + 4);
            }

            // Text offset is always next to 0x00000003.
            int intTextOffsetLabel = scriptBuffer.IndexOf(new byte[] { 0, 3, 0, 0, 0 }, 0, false);

            while (intTextOffsetLabel != -1)
            {
                // To get the actual offset, combine intTextOffsetLabel with 5.
                int intTextOffset = BitConverter.ToInt32(scriptBuffer, intTextOffsetLabel + 5);
                // We should always do the check in case of the modification of some important control bytes.
                if (intTextOffset > firstTextOffset && intTextOffset < scriptBuffer.Length)
                {
                    // Look up the text in original buffer.
                    byte[] bytesTextBlock = scriptBuffer.Slice(intTextOffset,
                                                               scriptBuffer.IndexOf(new byte[] { 0x00 },
                                                                                    intTextOffset, false));

                    if (bytesTextBlock != null)
                    {
                        // BGI treat 0x0A as new line.
                        string strText = Encoding.GetEncoding(codepageindex)
                                                 .GetString(bytesTextBlock)
                                                 .Replace("\n", @"\n");
                            StringBuilder s = new StringBuilder();
                            s.Clear();
                            s.AppendFormat("<{0},{1},{2}>{3}", intTextOffsetLabel + 5, intTextOffset, bytesTextBlock.Length, strText);
                            scr.Add(s.ToString());
                    }
                }

                // Search for the next.
                intTextOffsetLabel = scriptBuffer.IndexOf(new byte[] { 0, 3, 0, 0, 0 }, intTextOffsetLabel + 1, false);
            }

            if (output != "")
            {
                String[] r = (String[])scr.ToArray(typeof(string));
                WriteText(r, output);
                return r;
            }
            else
            {
                return ((String[])scr.ToArray(typeof(string)));
            }
        }

        /// <summary>
        /// Write a string array into a file, each string for a line.
        /// </summary>
        /// <param name="content">The string array that to be written.</param>
        /// <param name="destfile">The destination file that to be create.</param>
        public static void WriteText(String[] content, String destfile)
        {
            StreamWriter fw = new StreamWriter(new FileStream(destfile , FileMode.Create));
            foreach (String str in content)
            {
                fw.WriteLine(str);
            }
            fw.Close();
        }

        /// <summary>
        /// Search the given directory for target BGI scripts by the given filename pattern, using regular expression. Returns matched files.
        /// </summary>
        /// <param name="dir">Directory that contains BGI scripts.</param>
        /// <param name="target">Required filename pattern for searching.</param>
        /// <returns>Matched filenames array in full path.</returns>
        public static String[] GetScr(String dir, String target)
        {
            try
            {
                String[] items = Directory.EnumerateFiles(dir, target, System.IO.SearchOption.TopDirectoryOnly).ToArray<String>();
                return items;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show(MassConvert.ActiveForm, "指定的路径不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                String[] err = { "err" };
                return err;
            }
        }

        /// <summary>
        /// Get the filename of a specified path. Returns from the last slash.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="ext">Whether to use extension.</param>
        /// <returns>File name.</returns>
        public static String GetFileByPath(String path, Boolean ext)
        {
            if (ext)
                return System.IO.Path.GetFileName(path);
            else
                return System.IO.Path.GetFileNameWithoutExtension(path);
        }
    }
}
