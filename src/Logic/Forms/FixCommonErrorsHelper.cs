﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikse.SubtitleEdit.Logic.Forms
{
    public static class FixCommonErrorsHelper
    {

        public static string FixEllipsesStartHelper(string text)
        {
            if (text == null || text.Trim().Length < 4)
                return text;
            if (!text.Contains(".."))
                return text;

            if (text.StartsWith("..."))
            {
                text = text.TrimStart('.').TrimStart();
            }

            text = text.Replace("-..", "- ..");
            var tag = "- ...";
            if (text.StartsWith(tag))
            {
                text = "- " + text.Substring(tag.Length, text.Length - tag.Length);
                while (text.StartsWith("- ."))
                {
                    text = "- " + text.Substring(3, text.Length - 3);
                    text = text.Replace("  ", " ");
                }
            }

            tag = "<i>...";
            if (text.StartsWith(tag))
            {
                text = "<i>" + text.Substring(tag.Length, text.Length - tag.Length);
                while (text.StartsWith("<i>."))
                    text = "<i>" + text.Substring(4, text.Length - 4);
                while (text.StartsWith("<i> "))
                    text = "<i>" + text.Substring(4, text.Length - 4);
            }
            tag = "<i> ...";
            if (text.StartsWith(tag))
            {
                text = "<i>" + text.Substring(tag.Length, text.Length - tag.Length);
                while (text.StartsWith("<i>."))
                    text = "<i>" + text.Substring(4, text.Length - 4);
                while (text.StartsWith("<i> "))
                    text = "<i>" + text.Substring(4, text.Length - 4);
            }

            tag = "- <i>...";
            if (text.StartsWith(tag))
            {
                text = "- <i>" + text.Substring(tag.Length, text.Length - tag.Length);
                while (text.StartsWith("- <i>."))
                    text = "- <i>" + text.Substring(6, text.Length - 6);
            }
            tag = "- <i> ...";
            if (text.StartsWith(tag))
            {
                text = "- <i>" + text.Substring(tag.Length, text.Length - tag.Length);
                while (text.StartsWith("- <i>."))
                    text = "- <i>" + text.Substring(6, text.Length - 6);
            }

            // Narrator:... Hello foo!
            text = text.Replace(":..", ": ..");
            tag = ": ..";
            if (text.Contains(tag))
            {
                text = text.Replace(": ..", ": ");
                while (text.Contains(": ."))
                    text = text.Replace(": .", ": ");
            }
            text = text.Replace("  ", " ");
            return text;
        }

    }
}
