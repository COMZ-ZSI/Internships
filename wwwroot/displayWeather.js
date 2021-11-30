function callAjax(city) {
    $.ajax({
        url: "https://localhost:44370/WeatherForecast",
    }).done(function (result) {

        let labels = [];
        let data = {
            labels: labels,
            datasets: [{
                label: 'Temperature for ' + city,
                backgroundColor: 'rgb(255, 99, 132)',
                borderColor: 'rgb(255, 99, 132)',
                data: [],
            }]
        };


        console.log(data);

       // let bt = $('#btn');


       // let form = $('#form');
        for (let i = 0; i < result.length; i++) {
            if (city == '') {
                document.getElementById('result').innerHTML = ""
                break
            }

            else if (result[i].name.includes(city.toUpperCase())) {
                result[i].forecasts.forEach(item => {
                    labels.push(item.date.slice(0, 10));
                    data.datasets[0].data.push(item.temperatureC);
                });
                const config = {
                    type: 'line',
                    data: data,
                    options: {}
                }
                //document.getElementById('result').innerHTML = `<div style="width: 1200px; height: 500px;"><h2>City</h2><div class="chartjs-size-monitor"><div class="chartjs-size-monitor-expand"><div class=""></div></div><div class="chartjs-size-monitor-shrink"><div class=""></div></div></div>
                //<canvas id="myChart" style="display: block; width: 930px; height: 465px;" width="930" height="465" class="chartjs-render-monitor"></canvas>
                //</div>`;
                var myChart = new Chart(
                    document.getElementById('myChart'),
                    config
                );
                break;
            }
            else {
                /*document.getElementById('result').innerHTML = "<h1> Bad Request </h1>"*/
            }
        }




    });
}

function drawChart(cityList, city) {

    //0: { Name: 'New York', Date: '2021-10-14T15:29:45Z', TemperatureC: 22.61, Summary: 'clear sky' }
    //1: { Name: 'New York', Date: '2021-10-14T15:00:17Z', TemperatureC: 21.91, Summary: 'clear sky' }

    console.log(cityList);

    let labels = [];
    let data = {
        labels: labels,
        datasets: [{
            label: 'Temperature for ' + city,
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: [],
        }]
    };

    for (let i = 0; i < cityList.length; i++) {
        if (city == '') {
            document.getElementById('result').innerHTML = ""
            break
        }

        else if (cityList.forEach(item => {
                labels.push(item.Date);
                data.datasets[0].data.push(item.TemperatureC);
            }));
            const config = {
                type: 'line',
                data: data,
                options: {}
            }
            //document.getElementById('result').innerHTML = `<div style="width: 1200px; height: 500px;"><h2>City</h2><div class="chartjs-size-monitor"><div class="chartjs-size-monitor-expand"><div class=""></div></div><div class="chartjs-size-monitor-shrink"><div class=""></div></div></div>
            //<canvas id="myChart" style="display: block; width: 930px; height: 465px;" width="930" height="465" class="chartjs-render-monitor"></canvas>
            //</div>`;
            var myChart = new Chart(
                document.getElementById('myChart'),
                config
            );
            break;
        }
       
}





//        for (let i = 0; i < result.length; i++) {
//            if (city == '') {
//                document.getElementById('result').innerHTML =''
//                break
//            }

//            else if (result[i].name.includes(city.toUpperCase())) {
//                result[i].forecasts.forEach(item => {
//                    labels.push(item.date.slice(0, 10));
//                    data.datasets[0].data.push(item.temperatureC);
//                });
//                const config = {
//                    type: 'line',
//                    data: data,
//                    options: {}
//                }
//                document.getElementById('result').innerHTML = `<div style="width: 1200px; height: 500px;"><h2>City</h2><div class="chartjs-size-monitor"><div class="chartjs-size-monitor-expand"><div class=""></div></div><div class="chartjs-size-monitor-shrink"><div class=""></div></div></div>
//                <canvas id="myChart" style="display: block; width: 930px; height: 465px;" width="930" height="465" class="chartjs-render-monitor"></canvas>
//                </div>`;
//                var myChart = new Chart(
//                    document.getElementById('myChart'),
//                    config
//                );
//                break;
//            }
//            else {
//                document.getElementById('result').innerHTML = "<h1> Bad Request </h1>"
//            }
//        }


//    });
//}




