const getData = async () => {
  const data = await fetch("https://localhost:7048/GetRandomQuestion");
  return data.json();
};

export default async function Play() {
  const data = await getData();
  console.log(data);
  return (
    <>
      <h1>teste</h1>
    </>
  );
}
