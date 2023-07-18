function generateGraph(questionNum, labels, data) {
    var chrt = document.getElementById(questionNum).getContext("2d");
    var chartId = new Chart(chrt, {
        type: 'bar',
        data: {
            labels: labels,     
            datasets: [{
                label: questionNum,
                data: data,
                backgroundColor: ["#001d6c", "#004144", "#31135e", "#4C0033"], 
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
        questionNum: "Question 1",
        question: "I have been bullied at school.",
        labels: ["Yes", "No", "Maybe"],
        data: [24, 19, 16],
        type: "single"
    },
    {
        questionNum: "Question 2",
        question: "I was bullied in the... (Check all that apply)",
        labels: ["In the past month", "In the past month", "This term", "This year", "More than a year ago"],
        data: [24, 19, 16, 7, 4],
        type: "multiple-choice"
    },
    {
        questionNum: "Question 3",
        question: "I was bullied...",
        labels: ["1 time", "2-3 times", "4-5 times", "6 or more times", "I don\'t know"],
        data: [24, 19, 16, 6, 3],
        type: "single"
    },
    {
        questionNum: "Question 4",
        question: "I was bullied by...",
        labels: ["A single student", "A group of students"],
        data: [19, 16],
        type: "single"
    },
    {
        questionNum: "Question 5",
        question: "Student who bullied me was a...",
        labels: ["A boy", "A girl", "Prefer not to say"],
        data: [24, 19, 16],
        type: "single"
    },
    {
        questionNum: "Question 6",
        question: "The student who bullied me was...",
        labels: ["Asian", "Black", "Hispanic", "Mutiracial ", "White", "I don\'t know", "I prefer not to say "],
        data: [24, 19, 16, 5, 37, 23, 15],
        type: "single"
    },
    {
        questionNum: "Question 7",
        question: "The students who bullied me were...",
        labels: ["A group of boys ", "A group of girls", "Both boys and girls", "Prefer not to say"],
        data: [24, 19, 16, 6],
        type: "single"
    },
    {
        questionNum: "Question 8",
        question: "The students who bullied me were... (check all)",
        labels: ["Asian", "Black", "Hispanic", "Mutiracial ", "White", "I don\'t know", "I prefer not to say "],
        data: [24, 19, 16, 5, 37, 23, 15],
        type: "multiple-choice"
    },
    {
        questionNum: "Question 9",
        question: "The student who bullied me was...",
        labels: ["Younger than me", "Same age as me", "Older than me", "Not Sure"],
        data: [24, 19, 16, 5],
        type: "single"
    },
    {
        questionNum: "Question 10",
        question: "I was bullied... (Check all that apply)",
        labels: ["During school", "After school (on-campus)", "After school (off-campus)", "Other"],
        data: [24, 19, 16, 23],
        type: "multiple-choice"
    },
    {
        questionNum: "Question 11",
        question: "The students who bullied me were...",
        labels: ["Younger than me", "Same age as me", "Older than me", "Mixed aged group", "Not Sure"],
        data: [24, 19, 16, 5, 37],
        type: "single"
    },
    {
        questionNum: "Question 12",
        question: "I was bullied... (Check all that apply)",
        labels: ["During school", "After school (on-campus)", "After school (off-campus)", "Other"],
        data: [24, 19, 16, 23],
        type: "multiple-choice"
    },
    {
        questionNum: "Question 13",
        question: "I was bullied... (Check all that apply)",
        labels: ["In class", "During free time", "In the restroom", "In the hallway", "At lunch", "During school activities ", "Locker room ", "Sports program at school", "Other "],
        data: [24, 19, 16, 5, 37, 32, 23, 5, 17],
        type: "multiple-choice"
    },
    {
        questionNum: "Question 14",
        question: "What happened? (Check all that apply)",
        labels: ["Someone said something to me", "Someone did something to me", "Someone posted something about me"],
        data: [24, 19, 16],
        type: "multiple-choice"
    },
    {
        questionNum: "Question 15",
        question: "What did the student or students say to you? ",
        labels: ["Threats", "Teasing", "Name-calling", "Ignored me", "Other "],
        data: [24, 19, 16, 5, 37],
        type: "single"
    },
    {
        questionNum: "Question 16",
        question: "What did the student or students do to you?",
        labels: ["Hit me", "Pushed me", "Horseplay", "Made me do something I did not want to", "Other"],
        data: [24, 19, 16, 5, 37],
        type: "single"
    },
    {
        questionNum: "Question 17",
        question: "How did the bullying occur?",
        labels: ["On a website/social media/app", "Through texting"],
        data: [24, 19],
        type: "single"
    },
    {
        questionNum: "Question 18",
        question: "They said these things to me because of...",
        labels: ["who I date", "my sexual orientation", "who I hang out with", "my looks", "my faith", "my culture", "my race", "I do well in school", "I don\'t do well in school", "what my family can afford", "what my family can\'t afford", "Other"],
        data: [24, 19, 16, 5, 24, 19, 16, 5, 23, 19, 24, 13],
        type: "single"
    },
    {
        questionNum: "Question 19",
        question: "They did these things to me because of...",
        labels: ["who I date", "my sexual orientation", "who I hang out with", "my looks", "my faith", "my culture", "my race", "I do well in school", "I don\'t do well in school", "what my family can afford", "what my family can\'t afford", "Other"],
        data: [24, 19, 16, 5, 24, 19, 16, 5, 23, 19, 24, 13],
        type: "single"
    },
    {
        questionNum: "Question 20",
        question: "What website or app did the student or students use?",
        labels: ["Facebook", "Whatsapp", "Instagram", "TikTok", "Snapchat", "Pinterest", "Reddit", "Twitter", "Yik Yak", "Youtube", "Other "],
        data: [24, 19, 16, 5, 37, 24, 19, 16, 5, 23, 18],
        type: "single"
    },
    {
        questionNum: "Question 21",
        question: "What website or app did the student or students use?",
        labels: ["Facebook", "Whatsapp", "Instagram", "TikTok", "Snapchat", "Pinterest", "Reddit", "Twitter", "Yik Yak", "Youtube", "Other "],
        data: [24, 19, 16, 5, 37, 24, 19, 16, 5, 37],
        type: "single"
    },
    {
        questionNum: "Question 22",
        question: "What did the student post?",
        labels: ["Pictures of me", "Mean messages about me", "Spreading rumors about me", "Other"],
        data: [24, 19, 16, 5],
        type: "single"
    },
    {
        questionNum: "Question 23",
        question: "They posted these things about because of...",
        labels: ["who I date", "my sexual orientation", "who I hang out with", "my looks", "my faith", "my culture", "my race", "I do well in school", "I don\'t do well in school", "what my family can afford", "what my family can\'t afford", "Other"],
        data: [24, 19, 16, 5, 24, 19, 32, 67, 78, 19, 24, 13],
        type: "single"
    },
    {
        questionNum: "Question 24",
        question: "How did you respond?",
        labels: ["Ignored them", "Told the person to stop", "I fought back", "Told a friend or peer", "Told my parents", "Told a teacher", "Reported it to the school", "I reported it to the school resource officer/police", "Other "],
        data: [24, 19, 16, 5, 37, 24, 19, 16, 5],
        type: "single"
    },

]

for (let i = 0; i <= 24; i++) {
    generateGraph(QUESTIONS[i].questionNum, QUESTIONS[i].labels, QUESTIONS[i].data)
}
