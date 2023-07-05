function showMobile() {

    let openSideBar = document.querySelector("#side");
    let hamburger = document.querySelector(".button-container").children;
    if (openSideBar.style.left < "0px") {
        openSideBar.style.cssText = `
            left: 0px;
            transition: 1s;
        `

        //turn sidebar hamburger into a X
        hamburger.item(0).style.cssText = `
                transform: rotate(45deg) translate(10px, 10px);
                transition: 1s
            `
        hamburger.item(1).style.cssText = `
                transform: rotate(-45deg) ;
                transition: 1s;
            `
    } else {
        openSideBar.style.cssText = `
            left: -13em;
            transition: 1s
        `

        //turn sidebar X into hamburger
        //hamburger.item(2).style.display = "block"
        hamburger.item(0).style.cssText = `
                transform: rotate(0deg);
                transition: 1s
            `
        hamburger.item(1).style.cssText = `
                transform: rotate(0deg);
                transition: 1s;
            `

    }
}
  
document.querySelector(".button-container").addEventListener("click", function () {
    showMobile()
}) //adds the onclick function to the button



function generateGraph(questionNum, labels, data) {
    var chrt = document.getElementById(questionNum).getContext("2d");
    var chartId = new Chart(chrt, {
        type: 'bar',
        data: {
            labels: labels,     
            datasets: [{
                label: questionNum,
                data: data,
                backgroundColor: ['rgb(1, 30, 65)', 'rgb(169, 146, 96)'],
                borderWidth: 2,
            }]
        },  
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    display: true,
                    labels: {
                        color: 'black',
                    }
                },
                tooltip: {
                    enabled: true,
                }
            },
            scales: {
                x: {
                    ticks: {
                        display:false
                    }
                }
            },
        },
    });
} //iterates through all the blocks to create graphs with default data

QUESTIONS = [
    {
        questionNum: "question 1",
        labels: ["Yes", "No", "Maybe"],
        data:[24,19,16]
    },
    {
        questionNum: "question 2",
        labels: ["In the past month", "In the past month", "This term", "This year","More than a year ago"],
        data: [24, 19, 16,7,4]
    },
    {
        questionNum: "question 3",
        labels: ["1 time", "2-3 times", "4-5 times", "6 or more times", "I don't know"],
        data: [24, 19, 16,6,3]
    },
    {
        questionNum: "question 4",
        labels: ["A single student", "A group of students"],
        data: [19, 16]
    },
    {
        questionNum: "question 5",
        labels: ["A boy", "A girl", "Prefer not to say"],
        data: [24, 19, 16]
    },
    {
        questionNum: "question 6",
        labels: ["Asian", "Black", "Hispanic", "Mutiracial ", "White", "I don’t know","I prefer not to say "],
        data: [24, 19, 16,5,37,23,15]
    },
    {
        questionNum: "question 7",
        labels: ["A group of boys ", "A group of girls", "Both boys and girls", "Prefer not to say"],
        data: [24, 19, 16,6]
    },
    {
        questionNum: "question 8",
        labels: ["Asian", "Black", "Hispanic", "Mutiracial ", "White", "I don’t know", "I prefer not to say "],
        data: [24, 19, 16, 5, 37, 23, 15]
    },
    {
        questionNum: "question 9",
        labels: ["Younger than me", "Same age as me", "Older than me", "Not Sure"],
        data: [24, 19, 16, 5]
    },
    {
        questionNum: "question 10",
        labels: ["During school", "After school (on-campus)", "After school (off-campus)", "Other"],
        data: [24, 19, 16, 23]
    },
    {
        questionNum: "question 11",
        labels: ["Younger than me", "Same age as me", "Older than me", "Mixed aged group", "Not Sure"],
        data: [24, 19, 16, 5, 37]
    },
    {
        questionNum: "question 12",
        labels: ["During school", "After school (on-campus)", "After school (off-campus)", "Other"],
        data: [24, 19, 16, 23]
    },
    {
        questionNum: "question 13",
        labels: ["In class", "During free time", "In the restroom", "In the hallway", "At lunch", "During school activities ", "Locker room ", "Sports program at school","Other "],
        data: [24, 19, 16, 5, 37,32,23,5,17]
    },
    {
        questionNum: "question 14",
        labels: ["Someone said something to me", "Someone did something to me", "Someone posted something about me"],
        data: [24, 19, 16]
    },
    {
        questionNum: "question 15",
        labels: ["Threats", "Teasing", "Name-calling", "Ignored me", "Other "],
        data: [24, 19, 16, 5, 37]
    },
    {
        questionNum: "question 16",
        labels: ["Hit me", "Pushed me", "Horseplay", "Made me do something I did not want to", "Other"],
        data: [24, 19, 16, 5, 37]
    },
    {
        questionNum: "question 17",
        labels: ["On a website/social media/app", "Through texting"],
        data: [24, 19]
    },
    {
        questionNum: "question 18",
        labels: ["who I date", "my sexual orientation", "who I hang out with", "my looks", "my faith", "my culture", "my race", "I do well in school", "I don’t do well in school", "what my family can afford", "what my family can’t afford", "Other"],
        data: [24, 19, 16, 5, 24, 19, 16, 5, 23, 19,24,13]
    },
    {
        questionNum: "question 19",
        labels: ["who I date", "my sexual orientation", "who I hang out with", "my looks", "my faith", "my culture", "my race", "I do well in school", "I don’t do well in school", "what my family can afford", "what my family can’t afford","Other"],
        data: [24, 19, 16, 5, 24, 19, 16, 5, 23, 19, 24, 13]
    },
    {
        questionNum: "question 20",
        question:"What website or app did the student or students use?",
        labels: ["Facebook", "Whatsapp", "Instagram", "TikTok", "Snapchat", "Pinterest", "Reddit", "Twitter", "Yik Yak", "Youtube","Other "],
        data: [24, 19, 16, 5, 37, 24, 19, 16, 5, 23,18]
    },
    {
        questionNum: "question 21",
        question: "What website or app did the student or students use?",
        labels: ["Facebook", "Whatsapp", "Instagram", "TikTok", "Snapchat", "Pinterest", "Reddit", "Twitter", "Yik Yak", "Youtube", "Other "],
        data: [24, 19, 16, 5, 37, 24, 19, 16, 5, 37]
    },
    {
        questionNum: "question 22",
        question: "What did the student post?",
        labels: ["Pictures of me", "Mean messages about me", "Spreading rumors about me", "Other"],
        data: [24, 19, 16, 5]
    },
    {
        questionNum: "question 23",
        question: "They posted these things about because of...",
        labels: ["who I date", "my sexual orientation", "who I hang out with", "my looks", "my faith", "my culture", "my race", "I do well in school", "I don’t do well in school", "what my family can afford", "what my family can’t afford", "Other"],
        data: [24, 19, 16, 5, 24, 19, 32, 67, 78, 19, 24, 13]
    },
    {
        questionNum: "question 24",
        question: "How did you respond?",
        labels: ["Ignored them", "Told the person to stop", "I fought back", "Told a friend or peer", "Told my parents", "Told a teacher", "Reported it to the school", "I reported it to the school resource officer/police","Other "],
        data: [24, 19, 16, 5, 37, 24, 19, 16, 5]
    },

]

for (let i = 0; i <= 24; i++) {
    generateGraph(QUESTIONS[i].questionNum, QUESTIONS[i].labels, QUESTIONS[i].data)
}
