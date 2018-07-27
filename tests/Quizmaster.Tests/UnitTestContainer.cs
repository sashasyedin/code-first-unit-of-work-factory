namespace Quizmaster.Tests
{
    public abstract class UnitTestContainer
    {
        /// <summary>
        /// Provides common asserts for all tests.
        /// </summary>
        protected virtual void AssertCore()
        {
        }

        /// <summary>
        /// Stubs the methods of the mocked dependencies.
        /// </summary>
        protected virtual void Stub()
        {
        }

        /// <summary>
        /// Performs useful initialisation before each and every test is executed.
        /// </summary>
        protected virtual void TestInitialise()
        {
        }
    }
}
