using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ApplicationSetting : SharedBase
    {
        public int ApplicationSettingID { get; set; }

        [MaxLength(100)]
        public string BusinessName { get; set; }

        [MaxLength(300)]
        public string BusinessAddress { get; set; }

        [MaxLength(10)]
        public string BusinessPhone { get; set; }

        [MaxLength(100)]
        public string BusinessEmail { get; set; }

        [MaxLength(100)]
        public string BusinessWebsite { get; set; }

        public DateTime BusinessAnniversary { get; set; }

        public byte[] Logo { get; set; }

        public decimal PercentagePoints { get; set; }

        public decimal PointValueCash { get; set; }

        public bool RewardDoublePointsOnBusinessAnniversary { get; set; }

        public bool RewardDoublePointsOnCustomerAnniversary { get; set; }

        public bool AllowCashRequest { get; set; }
    }
}
