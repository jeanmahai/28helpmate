/*********************************************************************************************
// Copyright (c) 2012, Newegg (Chengdu) Co., Ltd. All rights reserved.
// Created by ViCTor.W.Ye at 3/12/2012 8:17:48 PM.
// E-Mail: Victor.W.Ye@newegg.com
// Class Name : MailTemplate
// CLR Version : 4.0.30319.239
// Target Framework : 3.5
// Description :
//
//*********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Utility
{
    public class MailTemplate
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// 模板是否属于HTML类型
        /// </summary>
        public bool IsHtmlType { get; set; }

        /// <summary>
        /// 模板邮件发送时的Priority
        /// </summary>
        public int MailPriority { get; set; }

        /// <summary>
        /// 发件人地址
        /// </summary>
        public string Sender { get; set; }


        /// <summary>
        /// 发件人显示名称
        /// </summary>
        public string SenderDisplayName { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 模板邮件主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 模板邮件内容
        /// </summary>
        public string Body { get; set; }
    }
}
