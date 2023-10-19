import React from "react";

import * as S from "./styles";
import { Shadows } from "../Shadows";

const DeskCard: React.FC<{ number: number; disabled?: boolean }> = ({
  number,
  disabled,
}) => {
  return (
    <Shadows width="60" height="60">
      <S.Container active={!disabled}>
        <S.Text>{number}</S.Text>
      </S.Container>
    </Shadows>
  );
};

export default DeskCard;
