﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lx.Domain.Shared.DataManager
{
    /// <summary>
    /// 人物详情状态
    /// </summary>
    public enum PeopleDetailStatus
    {
        /// <summary>
        /// 待审核
        /// </summary>
        WaitCheck,

        /// <summary>
        /// 审核通过
        /// </summary>
        CheckPass,

        /// <summary>
        /// 审核失败
        /// </summary>
        CheckFail,

        /// <summary>
        /// 无效
        /// </summary>
        Invalid,
    }
}
