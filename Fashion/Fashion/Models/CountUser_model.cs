using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class CountUser_model
    {
        public int specialConsultCount;//特定咨询条数
        public int zhuTieCount;//提问条数，发帖条数
        public int replyCount;//回帖条数
        public int collectCount;//收藏贴子数
        public int concernsCount;//关注数，我关注了多少人                       	   
        public int fansCount;//粉丝数，我被多少人关注了                          	   
        public int supportCount;//获赞数，有多少人点赞我，或感谢我
    }
}