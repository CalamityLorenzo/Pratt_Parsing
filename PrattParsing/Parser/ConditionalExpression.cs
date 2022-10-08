namespace PrattParsing.Parser
{
    internal record ConditionalExpression : Expression
    {
        private readonly Expression condition;
        private readonly Expression thenArm;
        private readonly Expression elseArm;

        public ConditionalExpression(Expression condition, Expression thenArm, Expression elseArm)
        {
            this.condition = condition;
            this.thenArm = thenArm;
            this.elseArm = elseArm;
        }

    }
}
