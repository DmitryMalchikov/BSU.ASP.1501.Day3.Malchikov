using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polynom;
using NUnit.Framework;

namespace Polynom.Tests
{
    public class PolynomTests
    {
        static object[] addCases =
        {
            new object[] {new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,2,3 }), new Polynom(new double[] {2,4,6 }) },
            new object[] {new Polynom(new double[] { 0,2,3}), new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,4,6 }) },
            new object[] {new Polynom(new double[] { 0,2}), new Polynom(new double[] {1,2,3 }), new Polynom(new double[] { 1,4,3}) },
            new object[] {new Polynom(new double[] { 0}), new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,2,3 }) },
            new object[] {new Polynom(new double[] { 0,0,3}), new Polynom(new double[] { 0,0,3}), new Polynom(new double[] {0,0,6 }) }
        };

        static object[] multiplyCases =
{
            new object[] {new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,2,3 }), new Polynom(new double[] {1,4,10,12,9 }) },
            new object[] {new Polynom(new double[] { 0,2,3}), new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {0,2,7,12,9 }) },
            new object[] {new Polynom(new double[] { 0,2}), new Polynom(new double[] {1,2,3 }), new Polynom(new double[] { 0,2,4,6}) },
            new object[] {new Polynom(new double[] { 0}), new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {0 }) },
            new object[] {new Polynom(new double[] { 0,0,3}), new Polynom(new double[] { 0,0,3}), new Polynom(new double[] {0,0,0,0,9 }) },
            new object[] {new Polynom(new double[] { }), new Polynom(new double[] { }), new Polynom(new double[] { }) }
        };

        static object[] subtractCases =
{
            new object[] {new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,2,3 }), new Polynom(new double[] {0}) },
            new object[] {new Polynom(new double[] { 0,2,3}), new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {-1 }) },
            new object[] {new Polynom(new double[] { 0,2}), new Polynom(new double[] {1,2,3 }), new Polynom(new double[] { -1,0,-3}) },
            new object[] {new Polynom(new double[] { 0}), new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {-1,-2,-3 }) },
            new object[] {new Polynom(new double[] { 0,0,3}), new Polynom(new double[] { 0,0,3}), new Polynom(new double[] { }) },
            new object[] {new Polynom(new double[] { }), new Polynom(new double[] { }), new Polynom(new double[] { }) }
        };

        static object[] scalarMultiplyCases =
{
            new object[] {new Polynom(new double[] { 1,2,3}), 1, new Polynom(new double[] {1,2,3}) },
            new object[] {new Polynom(new double[] { 1,2,3}), 0, new Polynom(new double[] { }) },
            new object[] {new Polynom(new double[] { 1,2,3}), 3, new Polynom(new double[] { 3,6,9}) },
            new object[] {new Polynom(new double[] { 0}), 3, new Polynom(new double[] { }) },
            new object[] {new Polynom(new double[] { 0,0,3}), 3, new Polynom(new double[] {0,0,9 }) }
        };

        static object[] toStringCases =
        {
            new object[] {new Polynom(new double[] {1,2,3 }), "1 * x^0 + 2 * x^1 + 3 * x^2" },
            new object[] {new Polynom(new double[] {1 }), "1 * x^0" },
            new object[] {new Polynom(new double[] { }), String.Empty }
        };

        static object[] getHashCodeCases =
{
            new object[] {new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,2,3}), true },
             new object[] {new Polynom(new double[] { 0,2,3}), new Polynom(new double[] {1,2,3}), false },
             new object[] {new Polynom(new double[] { }), new Polynom(new double[] {0}), true }
        };

        static object[] equalsCases =
{
            new object[] {new Polynom(new double[] { 1,2,3}), new Polynom(new double[] {1,2,3}), true },
             new object[] {new Polynom(new double[] { 0,2,3}), new Polynom(new double[] {1,2,3}), false },
             new object[] {new Polynom(new double[] { }), new Polynom(new double[] {0}), true }
        };

        [Test, TestCaseSource(nameof(addCases))]
        public void Polynoms_Add(Polynom poly1, Polynom poly2, Polynom result)
        {
            Assert.IsTrue((poly1 + poly2).ToString() == result.ToString());
        }

        [Test, TestCaseSource(nameof(multiplyCases))]
        public void Polynoms_Multiply(Polynom poly1, Polynom poly2, Polynom result)
        {
            Assert.IsTrue((poly1 * poly2).ToString() == result.ToString());
        }

        [Test, TestCaseSource(nameof(subtractCases))]
        public void Polynoms_Subtract(Polynom poly1, Polynom poly2, Polynom result)
        {
            Assert.IsTrue((poly1 - poly2).ToString() == result.ToString());
        }

        [Test, TestCaseSource(nameof(scalarMultiplyCases))]
        public void Polynom_MultiplyScalar(Polynom poly1, double scalar, Polynom result)
        {
            Assert.IsTrue((poly1 * scalar).ToString() == result.ToString());
        }

        [Test, TestCaseSource(nameof(toStringCases))]
        public void Polynom_MultiplyScalar(Polynom poly1, string result)
        {
            Assert.IsTrue(poly1.ToString() == result.ToString());
        }

        [Test, TestCaseSource(nameof(getHashCodeCases))]
        public void Polynom_GetHashCode(Polynom poly1, Polynom poly2, bool result)
        {
            Assert.IsTrue((poly1.GetHashCode() == poly2.GetHashCode()) == result);
        }

        [Test, TestCaseSource(nameof(equalsCases))]
        public void Polynom_Equals(Polynom poly1, Polynom poly2, bool result)
        {
            Assert.IsTrue(poly1.Equals(poly2) == result);
        }
    }
}
