//
//
//

using System;
using System.Text;

namespace Neu
{
    public static partial class NodeHelpers
    {
        public static String Dump(
            this Node node)
        {
            return node.Dump(indent: 0);
        }

        public static String Dump(
            this Node node,
            int indent)
        {
            var i = Indent(indent);

            var t = node.GetType();

            var sb = new StringBuilder();

            if (node is Token tok)
            {
                var sourceTrimmed = tok.Source.Trim();

                sb.Append($"{i}{sourceTrimmed}");
            }
            else
            {
                sb.Append($"{i}{t.Name}");
            }
            
            foreach (var c in node.Children)
            {
                sb.Append('\n');

                sb.Append(c.Dump(indent + 1));
            }

            return sb.ToString();
        }

        private static String Indent(
            int indent)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < indent; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}