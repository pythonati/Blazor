window.blazoredRepairs = {

    buildChart: (element, type, data) => {
        var chart = new Chart(element, {
            type: type,
            data: data,
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        display: false
                    },
                    title: {
                        display: false
                    }
                }
            },
        });
    }
};
