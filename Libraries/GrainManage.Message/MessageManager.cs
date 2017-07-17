using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GrainManage.Message
{
    public sealed class MessageManager
    {
        private MessageManager() { }  //禁止外部实例化

        /// <summary>
        /// 根据选择器获取字典的键
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="selector">选择器</param>
        /// <param name="includeFullName">是否包含T类型名称</param>
        /// <returns></returns>
        public static string GetKey<T>(Expression<Func<T, int>> selector, bool includeFullName = true)
        {
            string key = string.Empty;
            if (selector != null)
            {
                var memberName = selector.Body.ToString();
                memberName = memberName.Split('.')[1].Trim();
                if (includeFullName)
                {
                    key = string.Format("{0}.{1}", typeof(T).FullName, memberName);
                }
                else
                {
                    key = memberName;
                }
            }
            return key;
        }
        /// <summary>
        /// 获取指定文件的配置信息
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        public static Dictionary<int, string> GetConfig(string path)
        {
            Dictionary<int, string> codeDic = new Dictionary<int, string>();
            if (!string.IsNullOrEmpty(path))
            {
                var allLines = System.IO.File.ReadAllLines(path);
                if (allLines != null && allLines.Length > 0)
                {
                    foreach (var line in allLines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var newLine = line.Trim();
                            if (Regex.IsMatch(newLine, @"^\d+\s+.*$"))
                            {
                                var match = Regex.Match(newLine, @"\s+");
                                if (match.Success)
                                {
                                    var index = newLine.IndexOf(match.Value);
                                    var key = newLine.Substring(0, index);
                                    var value = newLine.Substring(index + match.Value.Length);
                                    codeDic[int.Parse(key)] = value;
                                }
                            }
                        }
                    }
                }
            }
            return codeDic;
        }
        /// <summary>
        /// 获取指定类型的配置信息(包含全局配置文件信息)
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="includeFullName">是否包含T类型名称</param>
        public static Dictionary<string, MessageInfo> GetConfig(Type type, bool includeFullName = true)
        {
            var messDic = new Dictionary<string, MessageInfo>();
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.Instance).Where(f => f.MemberType == MemberTypes.Field || f.MemberType == MemberTypes.Property);
            if (members.Any())
            {
                var instance = Activator.CreateInstance(type);
                var codeDic = GetConfig(FilePath);
                foreach (var member in members)
                {
                    var key = includeFullName ? string.Format("{0}.{1}", type.FullName, member.Name) : member.Name;
                    var attributes = member.GetCustomAttributes(typeof(MessageAttribute), false) as MessageAttribute[];
                    if (attributes != null && attributes.Length > 0)
                    {
                        var attribute = attributes.First();
                        var message = attribute.Detail;
                        if (member.MemberType == MemberTypes.Field) //如果成员为字段类型，将使用该字段本身的值作为Code
                        {
                            var field = type.GetField(member.Name, BindingFlags.Public | BindingFlags.Instance);
                            if (field.FieldType == typeof(int))
                            {
                                message.Code = Convert.ToInt32(field.GetValue(instance));
                            }
                        }
                        if (attribute.AllowOverride && codeDic.Keys.Contains(message.Code))
                        {
                            message.Description = codeDic[message.Code];
                        }
                        messDic[key] = message;
                    }
                    else if (member.MemberType == MemberTypes.Field) //如果未设置Message特性,则提取全局配置文件中的信息
                    {
                        var field = type.GetField(member.Name, BindingFlags.Public | BindingFlags.Instance);
                        if (field.FieldType == typeof(int))
                        {
                            var code = Convert.ToInt32(field.GetValue(instance));
                            if (codeDic.Keys.Contains(code))
                            {
                                messDic[key] = new MessageInfo { Code = code, Description = codeDic[code] };
                            }
                            else
                            {
                                messDic[key] = new MessageInfo { Code = code, Description = string.Empty };
                            }
                        }
                    }
                    else
                    {
                        messDic[key] = null;
                    }
                }
            }
            return messDic;
        }
        /// <summary>
        /// 默认全局配置文件绝对路径
        /// </summary>
        public static string FilePath { private get; set; }
    }
}