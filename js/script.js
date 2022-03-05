// // Test event
// document.addEventListener("DOMContentLoaded", function () {
//     let run = document.getElementById("run");

//     run.addEventListener("click", function () {
//         let x = Number(document.getElementById("x").value);
//         let n = Number(document.getElementById("n").value);
//         let ele = document.getElementById("result");
//         let result = null;
//         ele.innerHTML = "";

//         result = bai16(x, n);
//         ele.innerHTML += "Bai 16:" + result + "<br>";

//         result = bai17(n);
//         ele.innerHTML += "Bai 17:" + result + "<br>";

//         result = bai18(x, n);
//         ele.innerHTML += "Bai 18:" + result + "<br>";

//         result = bai19(x, n);
//         ele.innerHTML += "Bai 19:" + result + "<br>";

//         result = bai20(x, n);
//         ele.innerHTML += "Bai 20:" + result + "<br>";

//         let k = Number(document.getElementById("k").value);
//         let maxtrix = [
//             [1, 2, 3],
//             [4, 5, 6],
//             [7, 8, 9],
//             [10, 11, 12],
//             [1, 2, 5],
//         ];
//         result = bai21(maxtrix, k);
//         ele.innerHTML += `
//             Bài 21:
//             <br>
//                 max: ${result.max}<br>
//                 min: ${result.min}<br>
//                 find: ${result.find}<br>
//         `;

//         let array26 = [10, 20, 30, 20, 50, 10, 40];
//         result = bai26(array26);
//         ele.innerHTML += `
//             Bài 26: ${result} <br>
//         `;

//         let array27 = [1, 1, 2, 2, 3, 3, 3, 2, 4];
//         result = bai27(array27);
//         ele.innerHTML += `
//             Bài 27: ${result} <br>
//         `;

//         result = bai28(n);
//         ele.innerHTML += `
//             Bài 28: ${result} <br>
//         `;

//         let array29 = ["mot", "hai", "ba", "nam"];
//         result = bai29(array29);
//         ele.innerHTML += `
//             Bài 29: ${result} <br>
//         `;

//         let string30 = "fuck";
//         result = bai30(string30);
//         ele.innerHTML += `
//             Bài 30: ${result} <br>
//         `;
//     });
// });

const prompt = require("prompt-sync")();

let x, n;
console.log("bai 16");
x = Number(prompt("nhap x: "));
n = Number(prompt("nhap n: "));
console.log(bai16(x, n));

console.log("bai 17");
n = Number(prompt("nhap n: "));
console.log(bai17(n));

console.log("bai 18");
x = Number(prompt("nhap x: "));
n = Number(prompt("nhap n: "));
console.log(bai18(x, n));

console.log("bai 19");
x = Number(prompt("nhap x: "));
n = Number(prompt("nhap n: "));
console.log(bai19(x, n));

console.log("bai 20");
x = Number(prompt("nhap x: "));
n = Number(prompt("nhap n: "));
console.log(bai20(x, n));

let k;
let maxtrix = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
    [10, 11, 12],
    [1, 2, 5],
];

let maxtrixShow = `[
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
    [10, 11, 12],
    [1, 2, 5],
]`;
console.log("bai 21");
console.log(maxtrixShow);
k = Number(prompt("nhap k: "));
console.log(bai21(maxtrix, k));

console.log("bai 26");
let dayso = prompt("nhap day so ( phan cach bang dau ','): ");

dayso = dayso.split(",");
console.log(bai26(dayso));

console.log("bai 27");
let dayso = prompt("nhap day so ( phan cach bang dau ','): ");

dayso = dayso.split(",");
console.log(bai27(dayso));

console.log("bai 28");
n = Number(prompt("nhap n: "));
console.log(bai28(n));

console.log("bai 29");
let dayso = prompt("nhap day chu ( phan cach bang dau ','): ");

dayso = dayso.split(",");
console.log(bai29(dayso));

console.log("bai 30");
let words = prompt("nhap chu: ");
console.log(bai30(words));

function bai16(x, n) {
    let s = x;
    for (let i = 2; i <= n; i++) {
        let tong = 0;
        for (let j = 1; j <= i; j++) {
            tong += j;
        }
        s += (x * i) / tong;
    }
    return s;
}
function bai17(n) {
    let s = 1;
    for (let i = 2; i <= n; i++) {
        s *= i;
    }
    return s;
}
function bai18(x, n) {
    let s = 1;
    let tich = 1;
    let giaithua = 1;
    for (let i = 2; i <= n; i++) {
        tich = x * i;
        giaithua = 1;
        for (let j = 2; j <= i; j++) {
            giaithua *= j;
        }
        s += tich / giaithua;
    }
    return s;
}
function bai19(x, n) {
    let s = 1;
    let tich = 1;
    let giaithua = 1;
    for (let i = 2; i <= n; i++) {
        tich = x * i * 2;
        giaithua = 1;
        for (let j = 2; j <= i * 2; j++) {
            giaithua *= j;
        }
        s += tich / giaithua;
    }
    return s;
}
function bai20(x, n) {
    let s = 1 + x;
    let tich = 1;
    let giaithua = 1;
    for (let i = 2; i <= n; i++) {
        tich = x * (2 * i) + 1;
        giaithua = 1;
        for (let j = 2; j <= i * 2 + 1; j++) {
            giaithua *= j;
        }
        s += tich / giaithua;
    }
    return s;
}
function bai21(matrix = [], k) {
    // x dong , n cot
    let result = {
        min: -1,
        max: -1,
        find: [],
    };

    for (i = 0; i < matrix.length; i++) {
        for (i = 0; i < matrix.length; i++) {
            for (j = 0; j < matrix[i].length; j++) {
                if (matrix[i][j] > result.max) {
                    result.max = matrix[i][j];
                }
                if (matrix[i][j] < result.min || result.min == -1) {
                    result.min = matrix[i][j];
                }
                if (matrix[i][j] == k) {
                    result.find.push(`(${i},${j})`);
                }
            }
        }
    }

    result.find = result.find.join(",");
    return result;
}

function bai26(array = []) {
    let result = [];

    let tmpIndex = {};
    for (let i = 0; i < array.length; i++) {
        tmpIndex[Number(array[i])] = 0;
    }

    for (let i = 0; i < array.length; i++) {
        tmpIndex[Number(array[i])] += 1;
    }

    for (let [key, value] of Object.entries(tmpIndex)) {
        if (value == 1) {
            result.push(key);
        }
    }

    return result.join(",");
}

function bai27(array = []) {
    let result = [];

    let tmpIndex = {};
    for (let i = 0; i < array.length; i++) {
        tmpIndex[array[i]] = 0;
    }

    for (let i = 0; i < array.length; i++) {
        tmpIndex[array[i]] += 1;
    }

    for (let [key, value] of Object.entries(tmpIndex)) {
        result.push(key);
    }

    return result.join(",");
}

function bai28(n) {
    result = 0;
    if (n == 1) {
        result = 1;
    } else if (n == 0) {
        result = 0;
    } else {
        let cachDi = [[]];
        for (let i = 0; i < n; i++) {
            cachDi[0][i] = 1;
        }

        let tongDu = n;
        let nextIndex = cachDi.length;
        while (tongDu > 1) {
            tongDu -= 2;
            nextIndex = cachDi.length;
            cachDi[nextIndex] = [];

            for (let i = 0; i < (n - tongDu) / 2; i++) {
                cachDi[nextIndex].push(2);
            }

            for (let i = 0; i < tongDu; i++) {
                cachDi[nextIndex].push(1);
            }
        }

        for (let i = 0; i < cachDi.length; i++) {
            if (cachDi[i].indexOf(1) > -1 && cachDi[i].indexOf(2) > -1) {
                result += cachDi[i].length;
            } else {
                result += 1;
            }
        }
    }

    return result;
}

function bai29(arryWords) {
    let result = { 0: "" };
    let maxLen = 0;
    for (let i = 0; i < arryWords.length; i++) {
        if (typeof result[arryWords[i].length] === "undefined") {
            result[arryWords[i].length] = [];
        }
        if (arryWords[i].length > maxLen) {
            maxLen = arryWords[i].length;
        }
        result[arryWords[i].length].push(arryWords[i]);
    }

    return result[maxLen].join(",");
}

function bai30(words = "") {
    let result = true;
    let arrayWords = words.split("");
    let objCount = {};
    for (let i = 0; i < arrayWords.length; i++) {
        if (typeof objCount[arrayWords[i]] === "undefined") {
            objCount[arrayWords[i]] = 0;
        }
        objCount[arrayWords[i]] += 1;
        if (objCount[arrayWords[i]] > 1) {
            return false;
        }
    }
    return result;
}
