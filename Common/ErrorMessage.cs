using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ErrorMessage
    {
        public string Type { get; set; }
            public int? StatusCode { get; set; }
            public string Title { get; set; }
            public string Detail { get; set; }

            public override string ToString()
            {
                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Type))
                {
                    sb.Append("|");
                    sb.Append($"Type: {Type}");
                }

                if (StatusCode.HasValue)
                {
                    sb.Append("|");
                    sb.Append($"StatusCode: {StatusCode}");
                }

                if (!string.IsNullOrEmpty(Title))
                {
                    sb.Append("|");
                    sb.Append($"Title: {Title}");
                }

                if (!string.IsNullOrEmpty(Detail))
                {
                    sb.Append("|");
                    sb.Append($"Detail: {Detail}");
                }

                return sb.ToString();
            }
        }
    }
