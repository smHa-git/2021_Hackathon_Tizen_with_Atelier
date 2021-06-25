# 2021_Hackathon_Tizen_with_Atelier

##Topic 1 : DL 모델을 활용한 센서 정보 결과 예측

###설명 :
REST API를 활용하여 Tizen에서 취득한 센서 정보를 Atelier AI Platform으로 전송 및 예측결과 수신합니다.
또한, Atelier AI Platform을 활용하여 수신된 센서 정보를 MongoDB에 저장, 가공을 통해 학습 데이터 생성 및 DL 학습을 통한 예측 결과를 도출합니다.

###문서 설명 :

- topic_1_sample_code.cs : topic1 c# 샘플 코드 입니다.
- sensor_data_temp.txt : 온도 데이터만 있는 센서 데이터 파일입니다.
- sensor_data.txt : 온도, 습도, 미세먼지, VOC 4종 센서의 데이터 파일입니다.

###Topic 1 샘플 코드 반환 값 :

문자열 반환 : OK! I got it. 


##Topic 2 : 이미지 데이터 학습 및 판단과 판단 결과에 따른 이미지 분류 모델을 이용한 이미지 분류 결과 서빙

###설명 : 
레이블링된 이미지 데이터를 활용하여 판단 및 분류 결과를 위한 이미지 데이터를 학습합니다.
REST API를 활용하여 Tizen에서 이미지 데이터를 Atelier AI Platform으로 전송하여 이미지의 판단 결과와 이미지 분류 모델을 이용한 판단 결과에 따른 이미지 분류 결과를 도출합니다.

###문서 설명 :

- topic_2_sample_code.cs : topic2 c# 샘플 코드 입니다.
- image 폴더 : 이미지 예측 결과를 위한 샘플 이미지 파일입니다.

###Topic 2 샘플 코드 반환 값 :

JSON 데이터 반환 : 

점수 가 높은 순서로 5개의 분류 카테고리를 알려줍니다.

floatVal : 이미지 판별 점수 값, 

stringVal : 이미지 판별 점수에 따른 문자열

JSON 데이터 :

결과 데이터는 샘플코드의 "giantPanda.jpeg" 이미지를 판별 및 분류한 결과 값입니다.

{
    "outputs": {
        "scores": {
            "dtype": "DT_FLOAT",
            "tensorShape": {
                "dim": [
                    {
                        "size": "1"
                    },
                    {
                        "size" : "5"
                    }
                ]
            },
            "floatVal": [
                9.546637,
                6.6261067,
                4.3301826,
                4.094414,
                2.8160584
            ]
        },
        "classes": {
            "dtype" : "DT_STRING",
            "tensorHape": {
                "dim": [
                    {
                        "size": "1"
                    },
                    {
                        "size": "5"
                    }
                ]
            },
            "stringVal": [
                "giant panda, panda, panda bear, conn bear, Ailuropoda melanoleuca",
                "indri, indris, Indri indri, Indri brevicaudatus",
                "gibbon, Hylobates lar",
                "lesser panda, red panda, panda, bear cat, cat bear, Ailurus fulgens",
                "titi, titi monkey"
            ]
        }
    }
}