import React, { useCallback, useEffect, useState } from "react";

import * as S from "./styles";
import { FlatList, LogBox } from "react-native";
import DeskCard from "../../components/DeskCard";
import { getSetting } from "../stored/settings/getSetting";
import Spacer from "../../components/Spacer";

const Desks: React.FC = () => {
  LogBox.ignoreAllLogs();
  const [deskNumber, setDeskNumber] = useState(0);
  const desks: number[] = [];

  const getDesks = useCallback(async () => {
    const d = await getSetting();
    if (d.tables) {
      setDeskNumber(d.tables);
    }
  }, []);

  useEffect(() => {
    getDesks();
  }, [getDesks]);

  useEffect(() => {
    if (deskNumber) {
      for (let i = 1; i <= deskNumber; i++) {
        desks.push(i);
      }
    }
  }, [deskNumber]);

  return (
    <S.Container>
      <FlatList
        data={desks}
        renderItem={({ item }) => <DeskCard number={item} />}
        style={{
          paddingVertical: 24,
          paddingHorizontal: 16,
        }}
        contentContainerStyle={{
          gap: 16,
          flexDirection: "row",
          flexWrap: "wrap",
        }}
        showsVerticalScrollIndicator={false}
        ListFooterComponent={<Spacer height={40} />}
      />
    </S.Container>
  );
};

export default Desks;
