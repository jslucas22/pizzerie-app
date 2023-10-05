/* eslint-disable @typescript-eslint/no-non-null-assertion */
import React from "react";

import { ModalParams } from "../../../utils/modal";

import * as S from "./styles";
import Loading from "../../Loading";

interface Params {
  title: string;
  subtitle?: string;
  needReturn?: boolean;
  yesOrNo?: boolean;
  loading?: boolean;

  onClose: () => void;
}

type CBParam = string | number | void;

const ModalConfirm: React.FC<ModalParams<Params, CBParam>> = ({
  closeModal,
  params,
}) => {
  function onPress(confirmed: boolean) {
    if (!confirmed) {
      closeModal();
      if (params?.yesOrNo) {
        closeModal("n");
      }
    } else {
      if (params?.yesOrNo) {
        closeModal("y");
      } else {
        params!.onClose();
        if (params?.needReturn == true) {
          closeModal(1);
        } else {
          closeModal();
        }
      }
    }
  }

  return (
    <S.Container>
      <S.TitleText>{params!.title}</S.TitleText>
      {params?.loading ? (
        <Loading />
      ) : (
        <>
          {!!params?.subtitle && <S.SubText>{params?.subtitle}</S.SubText>}

          <S.RowView>
            <S.OptBtn
              style={S.styles.shadow}
              onPress={() => onPress(false)}
              isConfirm={false}
            >
              <S.OptBtnText isConfirm={false}>
                {params?.yesOrNo ? "Não" : "Cancelar"}
              </S.OptBtnText>
            </S.OptBtn>

            <S.OptBtn
              style={S.styles.shadow}
              onPress={() => onPress(true)}
              isConfirm
            >
              <S.OptBtnText isConfirm>Sim</S.OptBtnText>
            </S.OptBtn>
          </S.RowView>
        </>
      )}
    </S.Container>
  );
};

export default ModalConfirm;
