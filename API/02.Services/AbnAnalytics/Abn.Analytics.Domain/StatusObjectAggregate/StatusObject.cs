using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Domain
{
    public class StatusObject: DomainEntity
    {

     

        public Status Status { get; set; }


        public string StatusText => Status.ToString();


        public int Progress { get; set; } = 0;

        public string Result { get; set; }


        //todo: add resource based literals for localization

        [Required(ErrorMessageResourceName = "Required") ]
        [RegularExpression(@"^[a-zA-Zs]{1,100}" ,ErrorMessage ="the field {0} must only contains the a to z characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessageResourceName = "Required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public void SetProgress(int amount)
        {
            Progress = amount;
            if (Progress > 100)
                Progress = 100;

            if(Progress==100)
            {
                Status = Status.Completed;
            }
        }
        [NotMapped]
        public string ConnectionId { get; set; }
    }
}
