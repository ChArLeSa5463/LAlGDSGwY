// 代码生成时间: 2025-10-12 03:38:22
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileSplitMergeTool
{
    // 提供文件分割和合并的工具类
    public class FileSplitMergeTool
    {
        private const int DefaultChunkSize = 1024 * 1024 * 10; // 默认每个文件块的大小为10MB

        // 分割文件
        public async Task SplitFileAsync(string filePath, string outputDirectory, int chunkSize = DefaultChunkSize)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file {filePath} does not exist.");
            }

            try
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        int chunkNumber = 0;

                        while (fileStream.Position < fileStream.Length)
                        {
                            byte[] buffer = new byte[chunkSize];
                            int bytesRead = await reader.ReadAsync(buffer, 0, chunkSize);
                            string chunkFileName = Path.Combine(outputDirectory, $"chunk-{chunkNumber++:D4}.bin");
                            await WriteChunkAsync(chunkFileName, buffer, bytesRead);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while splitting the file: {ex.Message}", ex);
            }
        }

        // 合并文件块
        public async Task MergeFilesAsync(string outputFilePath, string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"The directory {directoryPath} does not exist.");
            }

            try
            {
                string[] chunkFiles = Directory.GetFiles(directoryPath, "*.bin");
                Array.Sort(chunkFiles); // 确保文件块按顺序排序

                using (FileStream fileStream = File.Create(outputFilePath))
                {
                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        foreach (string chunkFileName in chunkFiles)
                        {
                            byte[] buffer = await File.ReadAllBytesAsync(chunkFileName);
                            await writer.WriteAsync(buffer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while merging files: {ex.Message}", ex);
            }
        }

        // 辅助方法，用于写入文件块
        private async Task WriteChunkAsync(string filePath, byte[] buffer, int bytesRead)
        {
            using (FileStream fileStream = File.Create(filePath))
            {
                await fileStream.WriteAsync(buffer, 0, bytesRead);
            }
        }
    }
}
