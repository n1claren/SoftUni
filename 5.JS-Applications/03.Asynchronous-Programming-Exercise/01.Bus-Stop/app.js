async function getInfo() {
    const input = document.getElementById('stopId');
    const id = input.value;
    const url = 'http://localhost:3030/jsonstore/bus/businfo/' + id;

    try {
        const ulElement = document.getElementById('buses');
        ulElement.innerHTML = '';

        const response = await fetch(url);
        const data = response.json();

        document.getElementById('stopName').textContent = data.name;
        const ulElement = document.getElementById('buses');
        
        Object.entries(data.buses).map(([bus, time]) => {
            const result = document.createElement('li');
            result.textContent = `Bus ${bus} arrives in ${time} minutes`;

            ulElement.appendChild(result);
        })

        input.value = '';
    } catch (error) {
        document.getElementById('stopName').textContent = 'Error';
    }
}