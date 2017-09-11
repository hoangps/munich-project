using System;
using System.Collections.Generic;
using System.Linq;

namespace MunichProject.Models
{
    [Serializable]
    public class FolderModel
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

        // references
        public IEnumerable<FolderModel> Subfolders { get; set; }
        public IEnumerable<FileModel> Files { get; set; }


        public long GetSize()
        {
            var filesInFolderSize = Files?.Sum(f => f.Size) ?? 0;

            var foldersInFolderSize = Subfolders?.Select(folder => folder.GetSize()).Sum() ?? 0;

            return filesInFolderSize + foldersInFolderSize;
        }
    }
}