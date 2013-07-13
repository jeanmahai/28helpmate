using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Updater;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Utility.Update
{
    public class ZipHelper
    {
        /// <summary>   
        /// 解压Zip文件保留原目录
        /// </summary>   
        /// <param name="_depositPath">压缩文件路径</param>   
        /// <param name="_floderPath">解压的路径</param>   
        /// <returns></returns>   
        public static bool DeCompressionZip(string _depositPath, string _floderPath)
        {
            FileStream fs = null;
            try
            {
                using (ZipInputStream InpStream = new ZipInputStream(File.OpenRead(_depositPath)))
                {
                    ZipEntry ze = InpStream.GetNextEntry();//获取压缩文件中的每一个文件   
                    Directory.CreateDirectory(_floderPath);//创建解压文件夹   
                    while (ze != null)//如果解压完ze则是null   
                    {
                        if (ze.IsFile)//压缩zipINputStream里面存的都是文件。带文件夹的文件名字是文件夹\\文件名   
                        {
                            string[] strs = ze.Name.Split('/');//如果文件名中包含’\\‘则表明有文件夹   
                            if (strs.Length > 1)
                            {
                                //两层循环用于一层一层创建文件夹   
                                for (int i = 0; i < strs.Length - 1; i++)
                                {
                                    string floderPath = _floderPath;
                                    for (int j = 0; j < i; j++)
                                    {
                                        floderPath = floderPath + "\\" + strs[j];
                                    }
                                    floderPath = floderPath + "\\" + strs[i];
                                    Directory.CreateDirectory(floderPath);
                                }
                            }
                            fs = new FileStream(_floderPath + "\\" + ze.Name, FileMode.OpenOrCreate, FileAccess.Write);//创建文件   
                            //循环读取文件到文件流中   
                            while (true)
                            {
                                byte[] bts = new byte[1024];
                                int i = InpStream.Read(bts, 0, bts.Length);
                                if (i > 0)
                                {
                                    fs.Write(bts, 0, i);
                                }
                                else
                                {
                                    fs.Flush();
                                    fs.Close();
                                    break;
                                }
                            }
                        }
                        ze = InpStream.GetNextEntry();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            return false;
        }

    }
}
