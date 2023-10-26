namespace KJBrainDeveloperService.ServiceContracts
{

    /// <summary>
    /// Class for chart diagram Result
    /// </summary>
    public class TrainingStatisticsChartResult
    {
        /// <summary>
        /// Label list for chart diagram 
        /// </summary>
        public List<string> ChartLabel { get; set; }
        /// <summary>
        /// MemorySound chart data
        /// </summary>
        public List<string> MemorySoundChartData { get; set; }
        /// <summary>
        /// MemoryNumber chart data
        /// </summary>
        public List<string> MemoryNumberChartData { get; set; }
        /// <summary>
        /// MemoryMatrix chart data
        /// </summary>
        public List<string> MemoryMatrixChartData { get; set; }
        /// <summary>
        /// Math chart data
        /// </summary>
        public List<string> MathChartData { get; set; }
    }
}
