import React, { FC } from "react";

interface Props {
  firstQuestion: string;
  secondQuestion: string;
  vote: (option: string) => void;
}
const Options: FC<Props> = ({ firstQuestion, secondQuestion, vote }) => {
  return (
    <div className="container flex w-4/5 max-w-4xl">
      <div
        className="option left flex items-center justify-center h-52 cursor-pointer border-1 m-3"
        onClick={() => vote("1")}
      >
        <p>{firstQuestion}</p>
      </div>
      <div
        className="option right flex items-center justify-center h-52 cursor-pointer border-1 m-3"
        onClick={() => vote("2")}
      >
        <p>{secondQuestion}</p>
      </div>
    </div>
  );
};

export default Options;
