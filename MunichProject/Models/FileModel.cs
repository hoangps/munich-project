using System;

namespace MunichProject.Models
{
    [Serializable]
    public class FileModel
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
    }
}