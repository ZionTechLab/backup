var ctx = document.getElementById("myChart2").getContext('2d');
var myChart = new Chart(ctx, {
  type: 'pie',
  data: {
      labels: ["Rejected", "Started", "Completed"],
    datasets: [{
      backgroundColor: [
        "#2ecc71",  
       
        "#34495e",

        "#bc5090"
      ],
      data: [25, 20,55]
    }]
  }
});



var ctx2 = document.getElementById("myChart21").getContext('2d');
var myChart = new Chart(ctx2, {
    type: 'pie',
    data: {
        labels: ["Preventive", "Corrective"],
        datasets: [{
            backgroundColor: [
              "#2ecc71",

              "#34495e"

             
            ],
            data: [25, 20]
        }]
    }
});



var ctx = document.getElementById("myChart22").getContext('2d');
var myChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ["Finished", "Started", "Pause"],
        datasets: [{
            backgroundColor: [
              "#73879C",

              "#f44336",

              "#bc5090"
            ],
            data: [60, 20, 20]
        }]
    }
});