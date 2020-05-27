<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_country_group".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial454 TRIAL
 *
 * @property ResUsers $createU
 * @property ResUsers $writeU
 */
class ResCountryGroup extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_country_group';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name'], 'required'],
            [['name'], 'string'],
            [['create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial454'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial454' => 'Trial454',
        ];
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * {@inheritdoc}
     * @return ResCountryGroupQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResCountryGroupQuery(get_called_class());
    }
}
