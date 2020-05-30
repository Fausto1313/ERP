<?php

namespace app\controllers;
/*Librerias y extensiones a otros modulos de ser necesario*/
use Yii;
use app\models\ResEmployed;
use app\models\ResEmployedSearch;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;

class ResEmployedController extends Controller
{
    
    public function behaviors()
    {
        return [
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['POST'],
                ],
            ],
        ];
    }

    /**
     Este metodo permite lavisualizacion deuna vista al ser invocada desde otra vista, ya sea desde layout
     * u otros
     */
    public function actionIndex()
    {
        $searchModel = new ResEmployedSearch();
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('index', [
            'searchModel' => $searchModel,
            'dataProvider' => $dataProvider,
        ]);
    }

    /**
     * Displays a single ResEmployed model.
     * @param integer $id
     * @return mixed
     * @throws NotFoundHttpException if the model cannot be found
     */
    public function actionView($id)
    {
        return $this->render('view', [
            'model' => $this->findModel($id),
        ]);
    }

    /**
     Al dar click en el boton de nuevo este se encarga de mandar a la pantalla de creacion, 
     * aqui salva la informacion asignando el id y generando una vista que posteriormente podemos visualizar
     */
    public function actionCreate()
    {
        $model = new ResEmployed();

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->Id]);
        }

        return $this->render('create', [
            'model' => $model,
        ]);
    }

    /**
Metodo que actualiza los datos atraves del id este solo regresa a la misma pantalla de actualizar
     *      */
    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->Id]);
        }

        return $this->render('update', [
            'model' => $model,
        ]);
    }

    /**
  Metodo que ejecuta la accion eliminar este es pasado por post ya sea por el gridview o vista, retorna al index al terminar la accion   */
    public function actionDelete($id)
    {
        $this->findModel($id)->delete();

        return $this->redirect(['index']);
    }

    /**
 Metodo encargado de buscar el id de la vista
     * **/
    protected function findModel($id)
    {
        if (($model = ResEmployed::findOne($id)) !== null) {
            return $model;
        }

        throw new NotFoundHttpException('Esta Pagina no exista.');
    }
}
