function radar(speed, area) {
    const motorwaySpeedLimit = 130;
    const interstateSpeedLimit = 90;
    const citySpeedLimit = 50;
    const residentialSpeedLimit = 20;

    let speedLimit = 0;

    switch (area) {
        case 'motorway': speedLimit = motorwaySpeedLimit; break;
        case 'interstate': speedLimit = interstateSpeedLimit; break;
        case 'city': speedLimit = citySpeedLimit; break;
        case 'residential': speedLimit = residentialSpeedLimit; break;
    }

    if (speed <= speedLimit) {
        return `Driving ${speed} km/h in a ${speedLimit} zone`;
    }

    let speedOver = speed -speedLimit;
    let status = '';

    if (speedOver <= 20) {
        status = 'speeding';
    } else if (speedOver <= 40) {
        status = 'excessive speeding';
    } else {
        status = 'reckless driving';
    }

    return `The speed is ${speedOver} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
}

console.log(radar(40, 'city'));
console.log(radar(21, 'residential'));
console.log(radar(120, 'interstate'));
console.log(radar(200, 'motorway'));