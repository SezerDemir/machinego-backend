using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachinegoAPI.DataAccess.Models
{
    public class MachiceAttachment
    {
        public int MachineId { get; set; }
        public int AttachmentId { get; set; }

        public Attachment Attachment{ get; set; }
        public Machine Machine { get; set; }
    }
}
