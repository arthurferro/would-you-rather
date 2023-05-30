const { createApp } = Vue;

createApp({
  data() {
    return {
      question: {},
      loadingQuestion: false,
    };
  },
  async mounted() {
    const api = "https://localhost:7048";
    axios
      .get(`${api}/getRandomQuestion`)
      .then((response) => (this.question = response.data))
      .catch((error) => console.log(error));
  },
}).mount("#app");
