using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class User_model
    {
        //编号
        public int userId;
        //真是姓名
        public string realName;
        //用户名
        public string userName;
        public string password;
        public char sex;
        public int age;
        //手机号码
        public string phoneNumber;
        public string email;
        //用户等级或类型编号
        public char rank;
        //用户等级或类型名
        public string rankName;
        //星星数
        public int starCount;
        //是否开启信息提醒功能
        public bool isMessageRemind;
        //粉丝人数
        public int fansCount;
        //关注人数
        public int attentionCount;
        //发帖条数
        public int postCount;
        //上传视频数
        public int videoCount;
        //发表日志数
        public int journalCount;
        //收藏帖子数
        public int collectPost;
        //收藏日志数
        public int collectJournalCount;
        //收藏视频数
        public int collectVideoCount;
        //收到的消息条数
        public int messageCount;
        //邀请次数
        public int inviteCount;
        //被邀请数
        public int beInvitedCount;
    }
}