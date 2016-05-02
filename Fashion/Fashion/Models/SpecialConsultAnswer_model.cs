using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{
    public class SpecialConsultAnswer_model
    {
        public int specialAnswerId;//专家回答数据的id
        public string answerHtmlUrl;//专家解答的内容的静态htmlUrl
        public DateTime date;//专家解答的日期
        public SpecialConsult_model specialConsult_model;//用户特定咨询的数据对象实例
        /// <summary>
        /// 构造函数
        /// </summary>
        public SpecialConsultAnswer_model()
        {
            specialConsult_model = new SpecialConsult_model();
        }
    }
}