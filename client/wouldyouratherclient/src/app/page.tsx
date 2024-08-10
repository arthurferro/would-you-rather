"use client";
import { useState, useEffect } from "react";
import Options from "./components/Options";

export default function Home() {
  const apiHost = "localhost:7064";
  const [options, setQuestions] = useState({
    firstQuestion: "...",
    secondQuestion: "...",
    id: "",
  });
  const [results, setPercentages] = useState({
    firstQuestionPercentage: 0,
    secondQuestionPercentage: 0,
  });

  useEffect(() => {
    fetchOptions();
  }, []);

  const fetchOptions = async () => {
    try {
      const response = await fetch(`https://${apiHost}/api/Question`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });
      const data = await response.json();
      setQuestions(data);
    } catch (error) {
      console.error("Error fetching RandomQuestion", error);
    }
  };

  const vote = async (option: string) => {
    try {
      const response = await fetch(
        `https://${apiHost}/api/Question/${options.id}/${option}`,
        {
          method: "PUT",
        }
      );
      const data = await response.json();
      setPercentages({
        firstQuestionPercentage: data.firstQuestionPercentage,
        secondQuestionPercentage: data.secondQuestionPercentage,
      });
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div>
      <Options
        firstQuestion={options.firstQuestion}
        secondQuestion={options.secondQuestion}
        vote={vote}
      />
      <div className="result hidden">
        <p>{results.firstQuestionPercentage}</p>
        <p>{results.secondQuestionPercentage}</p>
      </div>
    </div>
  );
}
