using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class User_model
    {
        public int userId;//编号
        public string realName;//真是姓名
        public string userName;//用户名
        public string password;
        public string salt;
        public char sex;
        public int age;
        public string phoneNumber;//手机号码
        public string email;
        public char rank;//用户等级或类型编号
        public string rankName;//用户等级或类型名
        public int starCount;//星星数
        public bool isMessageRemind;//是否开启信息提醒功能
        public int fansCount;//粉丝人数
        public int attentionCount;//关注人数
        public int postCount;//发帖条数
        public int videoCount;//上传视频数
        public int journalCount;//发表日志数
        public int collectPost;//收藏帖子数
        public int collectJournalCount;//收藏日志数
        public int collectVideoCount;//收藏视频数
        public int messageCount;//收到的消息条数
        public int inviteCount;//邀请次数
        public int beInvitedCount;//被邀请数
    }
}