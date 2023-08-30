import React from "react";

import * as S from "./styles";
import { ScreenBaseProps } from "utils/index";

type Props = ScreenBaseProps<"Home">;

const Home: React.FC<Props> = ({ navigation, route }) => {
  return <S.Container></S.Container>;
};

export default Home;
