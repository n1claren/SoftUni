function solve(steps, stepSize, speedKmh) {
    const speed = speedKmh * 1000 / 3600;
    const distance = steps * stepSize;
    const restSeconds = Math.floor(distance / 500) * 60;
    const time = distance / speed + restSeconds;

    const hours = Math.floor(time/3600).toFixed(0).padStart(2, "0");
    const minutes = Math.floor((time - hours*3600) / 60).toFixed(0).padStart(2, "0");
    const seconds = (time - hours*3600 - minutes*60).toFixed(0).padStart(2, "0");

    console.log(`${hours}:${minutes}:${seconds}`);
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);