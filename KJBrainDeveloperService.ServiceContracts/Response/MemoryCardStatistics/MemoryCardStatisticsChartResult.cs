namespace KJBrainDeveloperService.ServiceContracts
{

    /// <summary>
    /// Class for chart diagram Result
    /// </summary>
    public class MemoryCardStatisticsChartResult
    {
        /// <summary>
        /// Label list for chart diagram 
        /// </summary>
        public List<string> ChartLabel { get; set; }
        /// <summary>
        /// Easy chart data
        /// </summary>
        public List<string> EasyChartData { get; set; }
        /// <summary>
        /// Medium chart data
        /// </summary>
        public List<string> MediumChartData { get; set; }
        /// <summary>
        /// Hard chart data
        /// </summary>
        public List<string> HardChartData { get; set; }
        /// <summary>
        /// Nightmare chart data
        /// </summary>
        public List<string> NightmareChartData { get; set; }
    }
}
