using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public class TypeAttachment
    {
        public int AttachmentId { get; set; }
        public int TypeId { get; set; }

        public Attachment Attachment { get; set; }
        public MachineType MachineType { get; set; }
    }
}
