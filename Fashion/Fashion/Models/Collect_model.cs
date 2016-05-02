using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class Collect_model
    {
        //收藏记录
        public int collectId; //收藏编号
        public string collectCollector;//收藏者
        public int collectPostId;//帖子编号
        public User_model Collector;//User_model类，拥有用户的信息，回帖者
        public Post_model Post_model;//原贴类，拥有原贴的信息
        /// <summary>
        /// 构造函数
        /// </summary>
        public Collect_model()
        {
            Collector = new User_model();
            Post_model = new Post_model();
        }
    }
}