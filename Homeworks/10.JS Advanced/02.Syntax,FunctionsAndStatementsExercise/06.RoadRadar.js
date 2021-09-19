function roadRadar(speed, area) {
    const motorwatLimit = 130;
    const interstateLimit = 90;
    const cityLimit = 50;
    const residentialLimit = 20;
    const speeding = 20;
    const excessiveSpeeding = 40;

    if (area == "residential") {

        if (speed <= residentialLimit) {
            return (`Driving ${speed} km/h in a ${residentialLimit} zone`);
        } else if (speed > residentialLimit && speed <= residentialLimit + speeding) {
            let limitStatus = 'speeding';
            return (`The speed is ${speed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${limitStatus}`);
        } else if (speed > residentialLimit && speed <= residentialLimit + excessiveSpeeding) {
            let limitStatus = 'excessive speeding';
            return (`The speed is ${speed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${limitStatus}`);
        } else if (speed > residentialLimit && speed > residentialLimit + excessiveSpeeding) {
            let limitStatus = 'reckless driving';
            return (`The speed is ${speed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${limitStatus}`);
        }

    } else if (area == "city") {

        if (speed <= cityLimit) {
            return (`Driving ${speed} km/h in a ${cityLimit} zone`);

        } else if (speed > cityLimit && speed <= cityLimit + speeding) {
            let limitStatus = 'speeding';
            return (`The speed is ${speed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${limitStatus}`);
        } else if (speed > cityLimit && speed <= cityLimit + excessiveSpeeding) {
            let limitStatus = 'excessive speeding';
            return (`The speed is ${speed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${limitStatus}`);
        } else if (speed > cityLimit && speed > cityLimit + excessiveSpeeding) {
            let limitStatus = 'reckless driving';
            return (`The speed is ${speed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${limitStatus}`);
        }

    }else if (area == "interstate") {

        if (speed <= interstateLimit) {
            return (`Driving ${speed} km/h in a ${interstateLimit} zone`);

        } else if (speed > interstateLimit && speed <= interstateLimit + speeding) {
            let limitStatus = 'speeding';
            return (`The speed is ${speed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${limitStatus}`);
        } else if (speed > interstateLimit && speed <= interstateLimit + excessiveSpeeding) {
            let limitStatus = 'excessive speeding';
            return (`The speed is ${speed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${limitStatus}`);
        } else if (speed > interstateLimit && speed > interstateLimit + excessiveSpeeding) {
            let limitStatus = 'reckless driving';
            return (`The speed is ${speed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${limitStatus}`);
        }

    }else if (area == "motorway") {

        if (speed <= motorwatLimit) {
            return (`Driving ${speed} km/h in a ${motorwatLimit} zone`);

        } else if (speed > motorwatLimit && speed <= motorwatLimit + speeding) {
            let limitStatus = 'speeding';
            return (`The speed is ${speed - motorwatLimit} km/h faster than the allowed speed of ${motorwatLimit} - ${limitStatus}`);
        } else if (speed > motorwatLimit && speed <= motorwatLimit + excessiveSpeeding) {
            let limitStatus = 'excessive speeding';
            return (`The speed is ${speed - motorwatLimit} km/h faster than the allowed speed of ${motorwatLimit} - ${limitStatus}`);
        } else if (speed > motorwatLimit && speed > motorwatLimit + excessiveSpeeding) {
            let limitStatus = 'reckless driving';
            return (`The speed is ${speed - motorwatLimit} km/h faster than the allowed speed of ${motorwatLimit} - ${limitStatus}`);
        }

    }

}

console.log(roadRadar(40, 'city'));
console.log(roadRadar(21, 'residential'));
console.log(roadRadar(120, 'interstate'));
console.log(roadRadar(200, 'motorway'));