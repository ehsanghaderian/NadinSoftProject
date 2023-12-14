namespace Infrastructure.Helpers.PaginationHelpers
{
    public class SearchInfo
    {
        public SearchInfo()
        {
            this.FieldValue = string.Empty;
            this.FieldName = string.Empty;
        }
        private string _operator;
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string Operator
        {
            get
            {
                switch (_operator)
                {
                    case "equals": return "=";
                    case "notEqual": return "!=";
                    case "contains": return "like";
                    case "lessThan": return "<";
                    case "lessThanOrEqual": return "<=";
                    case "greaterThan": return ">";
                    case "greaterThanOrEqual": return ">=";
                    default: return "=";
                }
            }
            set { _operator = value; }
        }
    }
}
