namespace Core.Util {
    public class EstonianPersonalCodeValidator {
        public bool Validate(string personalCode) {
            if (string.IsNullOrEmpty(personalCode) || personalCode.Length != 11 || !personalCode.All(char.IsDigit))
                return false;

            int[] weightsPhase1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            int[] weightsPhase2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };

            int centuryIndicator = int.Parse(personalCode.Substring(0, 1));
            int year = int.Parse(personalCode.Substring(1, 2));
            int month = int.Parse(personalCode.Substring(3, 2));
            int day = int.Parse(personalCode.Substring(5, 2));
            int serialNumber = int.Parse(personalCode.Substring(7, 3));
            int checksum = int.Parse(personalCode.Substring(10, 1));

            if (centuryIndicator < 1 || centuryIndicator > 6)
                return false;

            if (!IsValidDate(centuryIndicator, year, month, day))
                return false;

            int calculatedChecksum = CalculateChecksum(personalCode, weightsPhase1);
            if (calculatedChecksum == 10) {
                calculatedChecksum = CalculateChecksum(personalCode, weightsPhase2);
                if (calculatedChecksum == 10)
                    calculatedChecksum = 0;
            }

            return checksum == calculatedChecksum;
        }

        private bool IsValidDate(int centuryIndicator, int year, int month, int day) {
            int fullYear = (centuryIndicator <= 2 ? 1800 : centuryIndicator <= 4 ? 1900 : 2000) + year;

            if (month < 1 || month > 12)
                return false;

            if (day < 1 || day > DateTime.DaysInMonth(fullYear, month))
                return false;

            return true;
        }

        private int CalculateChecksum(string personalCode, int[] weights) {
            int sum = 0;
            for (int i = 0; i < 10; i++) {
                sum += int.Parse(personalCode[i].ToString()) * weights[i];
            }
            return sum % 11;
        }
    }
}
