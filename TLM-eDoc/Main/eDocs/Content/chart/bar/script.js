var ctx = document.getElementById("myChart4").getContext('2d');
var myChart = new Chart(ctx, {
  type: 'bar',
  data: {
      labels: ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"],
    datasets: [{
      label: 'Species  1',
      data: [12, 19, 3, 17, 28, 24, 7],
      backgroundColor: "rgba(153,255,51,1)"
    }, {
        label: 'Species 2',
      data: [30, 29, 5, 5, 20, 3, 10],
      backgroundColor: "rgba(255,153,0,1)"
    }]
  }
});