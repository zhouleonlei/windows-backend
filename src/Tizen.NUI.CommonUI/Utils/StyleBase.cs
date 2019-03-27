namespace Tizen.NUI.CommonUI
{
    public class StyleBase 
    {
        public StyleBase()
        {
        }

        protected object Content
        {
            get;
            set;
        }

        protected internal virtual Attributes GetAttributes()
        {
            return Content as Attributes;
        }
    }
}

