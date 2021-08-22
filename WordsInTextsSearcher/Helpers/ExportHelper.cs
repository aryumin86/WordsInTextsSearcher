using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Helpers
{
    public class ExportHelper
    {
        public IWorkbook CreateTermTextMatrixInXLSX(
            IEnumerable<TextTermsStat> textTermsStats, IEnumerable<Word> words,
            IEnumerable<TextAttribute> attrs, IEnumerable<TextAttrBinding> bindings)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("term-text-matrix");
            IRow headersRow = sheet1.CreateRow(0);
            var headerRowStyle = workbook.CreateCellStyle();
            var headerFont = workbook.CreateFont();
            headerFont.IsBold = true;
            headerRowStyle.SetFont(headerFont);
            headersRow.RowStyle = headerRowStyle;

            var numberHeaderCell = headersRow.CreateCell(0);
            numberHeaderCell.SetCellValue("Id");

            var titleHeaderCell = headersRow.CreateCell(1);
            titleHeaderCell.SetCellValue("Название");

            var textHeaderCell = headersRow.CreateCell(2);
            textHeaderCell.SetCellValue("Текст");

            var wordsDict = words.ToDictionary(x => x.Id, x => x.Text);

            int colNumber = 2;
            words = words.OrderBy(x => x.Id);
            foreach(var word in words)
            {
                var wordNameHeader = headersRow.CreateCell(++colNumber);
                wordNameHeader.SetCellValue(word.Text);
            }

            foreach(var attr in attrs)
            {
                var attrNameHeader = headersRow.CreateCell(++colNumber);
                attrNameHeader.SetCellValue(attr.Name);
            }

            var tagNameHeader = headersRow.CreateCell(++colNumber);
            tagNameHeader.SetCellValue("Тег");

            var textRermsStatsArr = textTermsStats.ToArray();
            for (int i = 0; i < textTermsStats.Count(); i++)
            {
                var row = sheet1.CreateRow(i+1);
                var textIdCell = row.CreateCell(0);
                textIdCell.SetCellValue(textRermsStatsArr[i].TextRecord.Id);

                var textTitleCell = row.CreateCell(1);
                textTitleCell.SetCellValue(textRermsStatsArr[i].TextRecord.Title);

                var textTextCell = row.CreateCell(2);
                textTextCell.SetCellValue(
                    textRermsStatsArr[i].TextRecord.Text.Length > 32000
                    ? textRermsStatsArr[i].TextRecord.Text.Substring(0, 32000) + "......TEXT_TOO_LONG:" + textRermsStatsArr[i].TextRecord.Text.Length
                    : textRermsStatsArr[i].TextRecord.Text);

                int columnNumber = 2;
                foreach(var word in words.ToArray())
                {
                    var wordInTextOccuerencesCountCell = row.CreateCell(++columnNumber);
                    wordInTextOccuerencesCountCell.SetCellValue(textRermsStatsArr[i].WordsCount[word.Id]);
                }

                foreach(var attr in attrs.ToList())
                {
                    var attrValueCell = row.CreateCell(++columnNumber);
                    bindings = bindings.ToList();
                    var binding = bindings
                        .FirstOrDefault(b => b.TextRecordId == textRermsStatsArr[i].TextRecord.Id
                        && b.AttributeId == attr.Id);
                    if (binding != null)
                    {                        
                        attrValueCell.SetCellValue(binding.TextAttributeValue.Value);
                    }
                }

                var textTagCell = row.CreateCell(++columnNumber);
                textTagCell.SetCellValue(textRermsStatsArr[i].TextRecord.Tag?.Text);
            }

            return workbook;
        }
    }
}
