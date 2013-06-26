/*********************************************************************************************
// Copyright (c) 2012, Newegg (Chengdu) Co., Ltd. All rights reserved.
// Created by ViCTor.W.Ye at 3/12/2012 8:15:30 PM.
// E-Mail: Victor.W.Ye@newegg.com
// Class Name : MailMessage
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
    public class MailMessageModel
    {
        /// <summary>
        /// 是否是Html类型的邮件
        /// </summary>
        public bool IsHtmlType { get; set; }

        /// <summary>
        /// 邮件的重要性 （0=普通，1=一般，2=重要)
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 发件人邮件地址
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// 发件人名称
        /// </summary>
        public string DisplaySenderName { get; set; }

        /// <summary>
        /// 收件人地址
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// 抄送人地址
        /// </summary>
        public string CCName { get; set; }

        /// <summary>
        /// 按送人地址
        /// </summary>
        public string BCCName { get; set; }

        /// <summary>
        /// 回复名称
        /// </summary>
        public string ReplyName { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public List<string> Attachments { get; set; }

    }
}
