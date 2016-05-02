using Fashion.Code.DAL;
using Fashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Code.BLL
{
    public class Collect_bll
    {
        /// <summary>
        /// 通过用户名获取某个用户userId的收藏的主贴
        /// 这次不用查询出全部的数据，只需查询一部分数据，因为不是用于详情内容，而是用于遍历
        /// 原贴id  原贴标题 原贴内容  原贴的第一张图片 日期
        /// 返回Collect_model;
        /// </summary>
        /// <param name="userId">用户id</param>       
        /// <returns></returns>
        public List<Collect_model> GetShortCollectPostData(int userId)
        {
            Collect_dal collect_dal = new Collect_dal();
            List<Collect_model> collect_modelList = collect_dal.GetShortCollectPostData(userId);
            return collect_modelList;
        }
    }
}