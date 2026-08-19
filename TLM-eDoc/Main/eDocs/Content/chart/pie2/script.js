jQuery(document).ready(function ($) {

            $('.easy-pie-chart-1').easyPieChart({
                easing: 'easeOutBounce',
                barColor: '#3b80da',
                scaleColor: false,
                trackColor: '#f2f2f2',
                rotate: 180,
                lineWidth: 20,

                
                
                onStep: function (from, to, percent) {
                    $(this.el).find('.percent1').text(Math.round(percent));
                }
            });
            $('.easy-pie-chart-2').easyPieChart({
                easing: 'easeOutBounce',
                barColor: '#a83bda',
                scaleColor: false,
                trackColor: '#f2f2f2',
                rotate: 180,
                lineWidth: 20,
                onStep: function (from, to, percent) {
                    $(this.el).find('.percent2').text(Math.round(percent));
                }
            });
            $('.easy-pie-chart-3').easyPieChart({
                easing: 'easeOutBounce',
                barColor: '#da3bb8',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
               lineWidth : 20,
                onStep: function (from, to, percent) {
                    $(this.el).find('.percent3').text(Math.round(percent));
                }
            });
        });
    
let chartThree = document.querySelector('.easy-pie-chart-3');

        let editOne = document.querySelector(".editing1>span:nth-child(1)");
        let editTwo = document.querySelector(".editing2>span:nth-child(1)");
        let editThree = document.querySelector(".editing3>span:nth-child(1)");

        // console.log(editOne);
        // console.log(editTwo);
        // console.log(editThree);


        let percentThree = chartThree.dataset.percent;

        editOne.addEventListener('input', changeChartPercentageOne);
        editTwo.addEventListener('input', changeChartPercentageTwo);
        editThree.addEventListener('input', changeChartPercentageThree);

        function changeChartPercentageOne() {
            let string = editOne.innerHTML;
            let string2 = editTwo.innerHTML;
            let string3 = editThree.innerHTML;
            let number = Number(string);
            let number2 = Number(string2);
            let number3 = Number(string3);
            let mid = Math.floor((number / (number + number2 + number3)) * 100);
            let mid2 = Math.floor((number2 / (number + number2 + number3)) * 100);
            let mid3 = Math.floor((number3 / (number + number2 + number3)) * 100);
            // console.log(Math.floor(mid));
            // console.log(number);
            let chartOne = document.querySelector('.easy-pie-chart-1');
            let percentOne = chartOne.dataset.percent;
            percentOne = `${mid}`;
            // console.log(percentOne);
            chartOne.dataset.percent = percentOne;
            // console.log(chartOne);
            let chartTwo = document.querySelector('.easy-pie-chart-2');
            let percentTwo = chartTwo.dataset.percent;
            percentTwo = `${mid2}`;
            // console.log(percentTwo);
            chartTwo.dataset.percent = percentTwo;

            let chartThree = document.querySelector('.easy-pie-chart-3');
            let percentThree = chartThree.dataset.percent;
            percentThree = `${mid3}`;
            // console.log(percentThree);
            chartThree.dataset.percent = percentThree;
            // console.log(chartThree);

            let spanOne = document.querySelector('.percent1');

            new EasyPieChart(chartOne, {
                easing: 'easeOutBounce',
                barColor: '#3b80da',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanOne.innerHTML = percentOne;


            let spanTwo = document.querySelector('.percent2');

            new EasyPieChart(chartTwo, {
                easing: 'easeOutBounce',
                barColor: '#a83bda',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanTwo.innerHTML = percentTwo;

            let spanThree = document.querySelector('.percent3');

            new EasyPieChart(chartThree, {
                easing: 'easeOutBounce',
                barColor: '#da3bb8',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanThree.innerHTML = percentThree;
        }




        function changeChartPercentageTwo() {
            let string = editOne.innerHTML;
            let string2 = editTwo.innerHTML;
            let string3 = editThree.innerHTML;
            let number = Number(string);
            let number2 = Number(string2);
            let number3 = Number(string3);
            let mid = Math.floor((number / (number + number2 + number3)) * 100);
            let mid2 = Math.floor((number2 / (number + number2 + number3)) * 100);
            let mid3 = Math.floor((number3 / (number + number2 + number3)) * 100);
            // console.log(Math.floor(mid));
            // console.log(number);
            let chartOne = document.querySelector('.easy-pie-chart-1');
            let percentOne = chartOne.dataset.percent;
            percentOne = `${mid}`;
            // console.log(percentOne);
            chartOne.dataset.percent = percentOne;
            // console.log(chartOne);
            let chartTwo = document.querySelector('.easy-pie-chart-2');
            let percentTwo = chartTwo.dataset.percent;
            percentTwo = `${mid2}`;
            // console.log(percentTwo);
            chartTwo.dataset.percent = percentTwo;

            let chartThree = document.querySelector('.easy-pie-chart-3');
            let percentThree = chartThree.dataset.percent;
            percentThree = `${mid3}`;
            // console.log(percentThree);
            chartThree.dataset.percent = percentThree;
            // console.log(chartThree);

            let spanOne = document.querySelector('.percent1');

            new EasyPieChart(chartOne, {
                easing: 'easeOutBounce',
                barColor: '#3b80da',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanOne.innerHTML = percentOne;


            let spanTwo = document.querySelector('.percent2');

            new EasyPieChart(chartTwo, {
                easing: 'easeOutBounce',
                barColor: '#a83bda',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanTwo.innerHTML = percentTwo;

            let spanThree = document.querySelector('.percent3');

            new EasyPieChart(chartThree, {
                easing: 'easeOutBounce',
                barColor: '#da3bb8',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanThree.innerHTML = percentThree;
        }


        function changeChartPercentageThree() {
            let string = editOne.innerHTML;
            let string2 = editTwo.innerHTML;
            let string3 = editThree.innerHTML;
            let number = Number(string);
            let number2 = Number(string2);
            let number3 = Number(string3);
            let mid = Math.floor((number / (number + number2 + number3)) * 100);
            let mid2 = Math.floor((number2 / (number + number2 + number3)) * 100);
            let mid3 = Math.floor((number3 / (number + number2 + number3)) * 100);
            // console.log(Math.floor(mid));
            // console.log(number);
            let chartOne = document.querySelector('.easy-pie-chart-1');
            let percentOne = chartOne.dataset.percent;
            percentOne = `${mid}`;
            // console.log(percentOne);
            chartOne.dataset.percent = percentOne;
            // console.log(chartOne);
            let chartTwo = document.querySelector('.easy-pie-chart-2');
            let percentTwo = chartTwo.dataset.percent;
            percentTwo = `${mid2}`;
            // console.log(percentTwo);
            chartTwo.dataset.percent = percentTwo;

            let chartThree = document.querySelector('.easy-pie-chart-3');
            let percentThree = chartThree.dataset.percent;
            percentThree = `${mid3}`;
            // console.log(percentThree);
            chartThree.dataset.percent = percentThree;
            // console.log(chartThree);

            let spanOne = document.querySelector('.percent1');

            new EasyPieChart(chartOne, {
                easing: 'easeOutBounce',
                barColor: '#3b80da',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanOne.innerHTML = percentOne;


            let spanTwo = document.querySelector('.percent2');

            new EasyPieChart(chartTwo, {
                easing: 'easeOutBounce',
                barColor: '#a83bda',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanTwo.innerHTML = percentTwo;

            let spanThree = document.querySelector('.percent3');

            new EasyPieChart(chartThree, {
                easing: 'easeOutBounce',
                barColor: '#da3bb8',
                trackColor: '#f2f2f2',
                scaleColor: false,
                rotate: 180,
                lineWidth: 20
            });

            spanThree.innerHTML = percentThree;
        }













//--------------------------------------------------------------------------------
//--------------------------------------------------------------------------------

   
//         let chartThree = document.querySelector('.easy-pie-chart-3');

//         let editOne = document.querySelector(".editing1>span:nth-child(1)");
//         let editTwo = document.querySelector(".editing2>span:nth-child(1)");
//         let editThree = document.querySelector(".editing3>span:nth-child(1)");

//         // console.log(editOne);
//         // console.log(editTwo);
//         // console.log(editThree);


//         let percentThree = chartThree.dataset.percent;

//         editOne.addEventListener('input', changeChartPercentageOne);
//         editTwo.addEventListener('input', changeChartPercentageTwo);
//         editThree.addEventListener('input', changeChartPercentageThree);

//         function changeChartPercentageOne() {
//             let string = editOne.innerHTML;
//             let number = Number(string);
//             // console.log(number);
//             let chartOne = document.querySelector('.easy-pie-chart-1');
//             let percentOne = chartOne.dataset.percent;
//             percentOne = `${number}`;
//             // console.log(percentOne);
//             chartOne.dataset.percent = percentOne;
//             // console.log(chartOne);


//             let spanOne = document.querySelector('.percent1');

//             new EasyPieChart(chartOne, {
//                 easing: 'easeOutBounce',
//                 barColor: '#3b80da',
//                 trackColor: '#f2f2f2',
//                 scaleColor: false,
//                 rotate: 180,
//                 lineWidth: 10
//             });

//             spanOne.innerHTML = percentOne;
//         }

//         function changeChartPercentageTwo() {
//             let string = editTwo.innerHTML;
//             let number = Number(string);
//             // console.log(number);
//             let chartTwo = document.querySelector('.easy-pie-chart-2');
//             let percentTwo = chartTwo.dataset.percent;
//             percentTwo = `${number}`;
//             // console.log(percentTwo);
//             chartTwo.dataset.percent = percentTwo;
//             // console.log(chartTwo);

//             let spanTwo = document.querySelector('.percent2');

//             new EasyPieChart(chartTwo, {
//                 easing: 'easeOutBounce',
//                 barColor: '#a83bda',
//                 trackColor: '#f2f2f2',
//                 scaleColor: false,
//                 rotate: 180,
//                 lineWidth: 10
//             });

//             spanTwo.innerHTML = percentTwo;
//         }

//         function changeChartPercentageThree() {
//             let string = editThree.innerHTML;
//             let number = Number(string);
//             // console.log(number);
//             let chartThree = document.querySelector('.easy-pie-chart-3');
//             let percentThree = chartThree.dataset.percent;
//             percentThree = `${number}`;
//             // console.log(percentThree);
//             chartThree.dataset.percent = percentThree;
//             // console.log(chartThree);

//             let spanThree = document.querySelector('.percent3');

//             new EasyPieChart(chartThree, {
//                 easing: 'easeOutBounce',
//                 barColor: '#da3bb8',
//                 trackColor: '#f2f2f2',
//                 scaleColor: false,
//                 rotate: 180,
//                 lineWidth: 10
//             });

//             spanThree.innerHTML = percentThree;
//         }