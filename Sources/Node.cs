//
//
//

using System;
using System.Collections.Generic;
using System.Text;

namespace Neu
{
    public partial class Node
    {      
        internal IEnumerable<Node> Children { get; init; }

        internal SourceLocation Start { get; init; }

        internal SourceLocation End { get; init; }

        ///
        
        public Node(
            IEnumerable<Node> children,
            SourceLocation start,
            SourceLocation end)
        {
            this.Children = children;
            this.Start = start;
            this.End = end;
        }
    }


    public partial class Node
    {
        public override String ToString()
        {
            return this.ToString(indent: 0);
        }

        public String ToString(
            int indent)
        {
            var i = Indent(indent);

            var t = this.GetType();

            var sb = new StringBuilder();

            if (this is Token tok)
            {
                var sourceTrimmed = tok.Source.Trim();

                sb.Append($"{i}{sourceTrimmed}");
            }
            else
            {
                sb.Append($"{i}{t.Name}");
            }
            
            foreach (var c in this.Children)
            {
                sb.Append('\n');

                sb.Append(c.ToString(indent + 1));
            }

            return sb.ToString();
        }

        public static String Indent(
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